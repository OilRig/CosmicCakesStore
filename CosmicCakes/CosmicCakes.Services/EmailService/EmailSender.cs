using System.Net;
using System.Net.Mail;
using System.Configuration;
using System;

namespace CosmicCakes.Services.EmailService
{
    public class EmailSender : IEmailSender
    {
        private string FromEmailAdress => ConfigurationManager.AppSettings["FromEmail"];
        private string ToEmailAdress   => ConfigurationManager.AppSettings["ToEmail"];
        private string SmtpServer      => ConfigurationManager.AppSettings["SMTPServer"];
        private int SmtpPort           => Convert.ToInt32(ConfigurationManager.AppSettings["SMTPServerPort"]);

        public void SendEmailOrder(string message)
        {           
            var from = new MailAddress(FromEmailAdress, "Заказ");

            var to = new MailAddress(ToEmailAdress);

            using (var m = new MailMessage(from, to))
            {
                m.Subject = "Заказ";
                m.Body = message;

                var smtp = new SmtpClient(SmtpServer, SmtpPort);
                smtp.Credentials = new NetworkCredential("cosmicakesofficial@gmail.com", "nora1996NORA");
                smtp.UseDefaultCredentials = true;
                smtp.Send(m);
            }
        }
    }
}
