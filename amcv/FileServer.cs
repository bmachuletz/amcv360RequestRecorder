using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace amcv
{
    class FileServer
    {
        public FileServer()
        {
            HttpListener listener = new HttpListener();
            // listener.Prefixes.Add("http://*:8081/");
            listener.Prefixes.Add("http://+:80/Temporary_Listen_Addresses/");
            listener.Start();
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    HttpListenerContext context = listener.GetContext();
                    Task.Factory.StartNew((ctx) =>
                    {
                        WriteFile((HttpListenerContext)ctx, @"C:\Users\BenMac\source\repos\amcv\amcv\bin\Debug\public.cer");
                    }, context, TaskCreationOptions.LongRunning);
                }
            }, TaskCreationOptions.LongRunning);
        }

        void WriteFile(HttpListenerContext ctx, string path)
        {
            var response = ctx.Response;
            using (FileStream fs = File.OpenRead(path))
            {
                string filename = Path.GetFileName(path);
                //response is HttpListenerContext.Response...
                response.ContentLength64 = fs.Length;
                response.SendChunked = false;
                response.ContentType = System.Net.Mime.MediaTypeNames.Application.Octet;
                response.AddHeader("Content-disposition", "attachment; filename=" + filename);

                byte[] buffer = new byte[64 * 1024];
                int read;
                using (BinaryWriter bw = new BinaryWriter(response.OutputStream))
                {
                    while ((read = fs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        bw.Write(buffer, 0, read);
                        bw.Flush(); //seems to have no effect
                    }

                    bw.Close();
                }

                response.StatusCode = (int)HttpStatusCode.OK;
                response.StatusDescription = "OK";
                response.OutputStream.Close();
            }
        }
    }
}
