using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCakes.Services.EmailService
{
    public class EmailSender : IEmailSender
    {
        public void SendMail(MailMessage message)
        {

            //var from = new MailAddress("cosmicakesofficial@gmail.com", "Order");

            //var to = new MailAddress("golubevanora1@gmail.com");

            //var m = new MailMessage(from, to);

            //m.Subject = "Заказ";

            //m.Body = order;
            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("cosmicakesofficial@gmail.com", "gbczgjgf2345");
            smtp.EnableSsl = true;
            smtp.Send(message);

        }
    }
}
