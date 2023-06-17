using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chemistry_app
{
    internal class EmailSender
    {
        public EmailSender()
        {

        }

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

        public static void SendCertificate(string toEmail, string nameOfTest, string nameOfFile)
        {
            string smtpServer = "smtp.mail.ru";
            int smtpPort = 587;
            string username = "sukhov_klim@mail.ru";
            string password = "e7fTzmi7Y63CYZL6t2CE";

            SmtpClient client = new SmtpClient(smtpServer, smtpPort);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(username, password);

            MailAddress fromEmail = new MailAddress("sukhov_klim@mail.ru");
            MailAddress toMail = new MailAddress(toEmail);

            MailMessage message = new MailMessage();
            message.From = fromEmail;
            message.To.Add(toMail);

            message.Subject = $"Поздравляем вас от комманды Chemistry_app с успешным прохождением теста {nameOfTest}";

            Attachment attachment = new Attachment(nameOfFile);
            message.Attachments.Add(attachment);

            client.Send(message);
        }
    }
}
