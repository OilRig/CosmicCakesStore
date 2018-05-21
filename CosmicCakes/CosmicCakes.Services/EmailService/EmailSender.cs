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
            using (SmtpClient smtp = new SmtpClient("aspmx.l.google.com", 25))
            {
                using (MailMessage email = new MailMessage("ibrzdnsv@gmail.com", "cosmicakesofficial@gmail.com"))
                {
                    email.Subject = "Заказ";
                    email.Body = message;

                    smtp.Send(email);
                }
            }
        }
    }
}
