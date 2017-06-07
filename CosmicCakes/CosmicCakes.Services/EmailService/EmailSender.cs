using System.Net;
using System.Net.Mail;

namespace CosmicCakes.Services.EmailService
{
    public class EmailSender : IEmailSender
    {
        public void SendEmailOrder(string message)
        {

            var from = new MailAddress("cosmicakesofficial@gmail.com", "Order");

            var to = new MailAddress("golubevanora1@gmail.com");

            using (var m = new MailMessage(from, to))
            {
                m.Subject = "Заказ";
                m.Body = message;

                var smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("xxxxxxxxxx", "xxxxxxxxxxxxx");
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
        }
    }
}
