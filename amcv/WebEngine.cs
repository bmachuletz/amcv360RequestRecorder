using System;
using System.IO;
using System.Net;

namespace amcv
{
    public class QihooRequest
    {
        public string cookie;
        public string body;
    }

    public static class WebEngine
    {
        public static bool Request_q_smart_360_cn(QihooRequest qihooRequest, out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://q.smart.360.cn/clean/cmd/send");

                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "*/*";
                request.KeepAlive = true;

                request.Headers.Set(HttpRequestHeader.Cookie, qihooRequest.cookie);
                request.UserAgent = "QihooSuperApp_NoPods/3.8.0 (iPhone; iOS 12.1.2; Scale/2.00)";
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "de-DE;q=1");
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "br, gzip, deflate");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = qihooRequest.body;

                byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(body);
                request.ContentLength = postBytes.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(postBytes, 0, postBytes.Length);
                stream.Close();

                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
                else return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (response != null) response.Close();
                return false;
            }

            return true;
        }
    }
}
