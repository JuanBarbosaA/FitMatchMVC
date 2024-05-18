using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using System.Net.Mail;
using System.Net;
using System.IO;


namespace CapaNegocio
{
    public class CN_Recursos
    {

        public static string GenerarClave()
        {
            string clave = Guid.NewGuid().ToString("N").Substring(0, 6);
            return clave;
        }


        //encriptacion de texto en sha256
        public static string ConvertirSha256(string texto)
        {

            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            byte[] textoConSal = Encoding.UTF8.GetBytes(texto).Concat(salt).ToArray();

            using(SHA256 hash = SHA256Managed.Create())
            {
                byte[] hashBytes = hash.ComputeHash(textoConSal);

                StringBuilder Sb = new StringBuilder();
                foreach (byte b in hashBytes)
                    Sb.Append(b.ToString("x2"));
                foreach (byte b in salt)
                    Sb.Append(b.ToString("x2"));

                return Sb.ToString();
            }

        }


        public static bool EnviarCorreo(string correo, string asunto, string mensaje)
        {
            bool resultado = false;

            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(correo);
                mail.From = new MailAddress("fitmatchaplicacion@gmail.com");
                mail.Subject = asunto;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient()
                {
                    Credentials = new NetworkCredential("fitmatchaplicacion@gmail.com", "jqquunwrbpsbajat"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,

                };

                smtp.Send(mail);
                resultado = true;
            }
            catch 
            {
                resultado = false;
            }

            return resultado;

        }



      
        public static string ConvertirBase64(string ruta, out bool conversion)
        {
            string textoBase64 = string.Empty;
            conversion = true;

            try
            {
                byte[] bytes = File.ReadAllBytes(ruta);
                textoBase64 = Convert.ToBase64String(bytes);
            }
            catch
            {
                conversion = false;
            }
            return textoBase64;
        }
    }
}
