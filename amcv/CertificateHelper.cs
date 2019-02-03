using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace amcv
{
    class CertificateHelper
    {
        static string certpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Certs");
        static string pfxCertpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Certs", "root.pfx");
        static string cerCertpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Certs", "public.cer");

        public static void MakeCert()
        {
            var ecdsa = ECDsa.Create(); // generate asymmetric key pair


            var req = new CertificateRequest("cn=RootCa", ecdsa, HashAlgorithmName.SHA256);
            req.CertificateExtensions.Add(
    new X509EnhancedKeyUsageExtension(
        new OidCollection
        {
                    new Oid("1.3.6.1.5.5.7.3.8")
        },
        true));
            req.CertificateExtensions.Add(
                            new X509BasicConstraintsExtension(false, false, 0, false));

            req.CertificateExtensions.Add(
                new X509KeyUsageExtension(
                    X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.NonRepudiation,
                    false));


            var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(5));




            if (!Directory.Exists(certpath))
            {
                try
                {
                    Directory.CreateDirectory(certpath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Unable to create ther path to the Certficates {0}", certpath));
                }
            }

            if (!File.Exists(pfxCertpath))
            {
                // Create PFX (PKCS #12) with private key
                File.WriteAllBytes(pfxCertpath, cert.Export(X509ContentType.Pfx, "12345"));
            }

            if (!File.Exists(cerCertpath))
            {
                // Create Base 64 encoded CER (public key only)
                File.WriteAllText(cerCertpath,
                    "-----BEGIN CERTIFICATE-----\r\n"
                    + Convert.ToBase64String(cert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks)
                    + "\r\n-----END CERTIFICATE-----");
            }
        }
    }
}



