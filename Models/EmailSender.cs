using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chemistry_app
{
    static class EmailSender
    {
        public static void SendCode(string code, string toEmail)
        {
            string smtpServer = "smtp.mail.ru";
            int smtpPort = 587;
            string username = "sukhov_klim@mail.ru";
            string password = "e7fTzmi7Y63CYZL6t2CE";

            SmtpClient client = new SmtpClient(smtpServer, smtpPort);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(username, password);


            MailMessage message = new MailMessage();
            message.From = new MailAddress("sukhov_klim@mail.ru");
            message.Subject = "Chemistry_app: код для завершения регистрации";
            message.Body = $"Спасибо что зарегистрировались на нашем сервисе!\nВаш код подтверждения: {code}";

            message.To.Add(toEmail);

            client.Send(message);
        }

        static void SendCertificate()
        {

        }
    }
}
