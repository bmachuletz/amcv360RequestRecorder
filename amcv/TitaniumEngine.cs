using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Http;
using Titanium.Web.Proxy.Models;

namespace amcv
{
    class TitaniumEngine
    {
        public CommandModel cmdModel;
        public event EventHandler<EventArgs>  CompleteHandler, CookieLoaded, StopCommandLoaded, StartCommandLoaded,
                                              ChargeCommandLoaded;

        ProxyServer myProxy;

        static string cerCertpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "public.cer");

        public TitaniumEngine()
        {
            cmdModel = new CommandModel();

            myProxy = new ProxyServer(true, false, false);
          
            myProxy.CertificateManager.CreateRootCertificate(true);

            myProxy.BeforeRequest += MyProxy_BeforeRequest;
            myProxy.BeforeResponse += MyProxy_BeforeResponse;
            var explicitEndPoint = new ExplicitProxyEndPoint(IPAddress.Any, 8000, true)
            {
          //      GenericCertificate = new X509Certificate2(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Certs", "root.pfx"), "Kennwort1!")
            };

            var certificate = explicitEndPoint.GenericCertificate;



            explicitEndPoint.BeforeTunnelConnectRequest += OnBeforeTunnelConnect;

            myProxy.AddEndPoint(explicitEndPoint);

            WriteCertificate();
            
       //     myProxy.SetAsSystemHttpProxy(explicitEndPoint);
       //     myProxy.SetAsSystemHttpsProxy(explicitEndPoint);
        }

        public void ProxyStart()
        {
            myProxy.Start();
        }

        public void ProxyStop()
        {
            myProxy.Stop();
        }

        public void WriteCertificate()
        {
            File.WriteAllBytes(cerCertpath, myProxy.CertificateManager.RootCertificate.Export(X509ContentType.Cert));
        }

        private Task OnBeforeTunnelConnect(object sender, TunnelConnectSessionEventArgs e)
        {

            string hostname = e.HttpClient.Request.RequestUri.Host;

            if (hostname.Contains("dropbox.com"))
            {
                //Exclude Https addresses you don't want to proxy
                //Useful for clients that use certificate pinning
                //for example dropbox.com
                e.DecryptSsl = false;
            }

            return Task.FromResult(0);

        }

        private Task MyProxy_BeforeResponse(object sender, Titanium.Web.Proxy.EventArguments.SessionEventArgs e)
        {
            return Task.FromResult(0);
        }

        private async Task MyProxy_BeforeRequest(object sender, Titanium.Web.Proxy.EventArguments.SessionEventArgs e)
        {
            //Console.WriteLine(e.HttpClient.Request.Url);
            if (e.HttpClient.Request.Url.Contains("q.smart.360.cn/clean/cmd/send"))
            {
                var requestHeaders = e.HttpClient.Request.Headers;
                var method = e.HttpClient.Request.Method.ToUpper();

                var header = e.HttpClient.Request.Headers.Where(c => c.Name == "Cookie").FirstOrDefault();
                if (header != null)
                {
                    if (string.IsNullOrEmpty(cmdModel.Cookie))
                    {
                        Console.WriteLine("Cookie: {0}", header.Value);
                        cmdModel.Cookie = header.Value.ToString();
                        CookieLoaded(this, null);
                    }
                }

                var body = Encoding.UTF8.GetString(await e.GetRequestBody());

                if (body.Contains("data=%7B%22mode%22%3A%22smartClean%22%7D&devType=3&from=mpc_ios&infoType=21005"))
                {
                    if (string.IsNullOrEmpty(cmdModel.StartCleaningCommand))
                    {
                        cmdModel.StartCleaningCommand = body;
                        StartCommandLoaded(this, null);
                    }
                }
                else if(body.Contains("data=%7B%22cmd%22%3A%22pause%22%7D&devType=3&from=mpc_ios&infoType=21017"))
                {
                    if (string.IsNullOrEmpty(cmdModel.StopCleaningCommand))
                    {
                        cmdModel.StopCleaningCommand = body;
                        StopCommandLoaded(this, null);
                    }
                }
                else if(body.Contains("data=%7B%22cmd%22%3A%22start%22%7D&devType=3&from=mpc_ios&infoType=21012"))
                {
                    if (string.IsNullOrEmpty(cmdModel.ChargeCleaningCommand))
                    {
                        cmdModel.ChargeCleaningCommand = body;
                        ChargeCommandLoaded(this, null);
                    }
                }
            }
           // return Task.FromResult(0);
           if(cmdModel.CmdFlags == CommandModel.CommandsFlags.Complete)
           {
                cmdModel.CmdFlags = CommandModel.CommandsFlags.None;
                CompleteHandler(this, null);
            }
        }
    }
}
