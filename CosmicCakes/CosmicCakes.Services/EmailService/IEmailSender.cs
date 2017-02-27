using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCakes.Services.EmailService
{
    public interface IEmailSender
    {
        void SendMail(MailMessage message);
    }
}
