using CosmicakesControlWebApp.Models;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.IO;
using System.Threading.Tasks;

namespace CosmicakesControlWebApp.Controllers
{
    public class NewsController : Controller
    {
        IUserSubscriptionRepository _subscribtionRepository;
        IEmailTemplateRepository _templateRepository;
        public NewsController(IUserSubscriptionRepository subscribtionRepository, IEmailTemplateRepository templateRepository)
        {
            _subscribtionRepository = subscribtionRepository;
            _templateRepository = templateRepository;
        }
        private void NotifyUsers(string content,IEnumerable<HttpPostedFileBase> attachedFiles, string templateName = "CC-News")
        {
            var users = _subscribtionRepository.GetAllSubscribedUsers();
            string messageTemplate = _templateRepository.GetTemplateByName(templateName).Body;

            users
                .ToList()
                .ForEach(u =>
            {
                var from = new MailAddress("cosmicakesofficial@gmail.com","Кондитерская Cosmic Cakes");
                var to = new MailAddress(u.Email);

                using (var message = new MailMessage(from, to))
                {
                    message.IsBodyHtml = true;
                    message.Body = messageTemplate.Replace("{firstName}", u.Name).Replace("{patronymic}", u.Patronymic).Replace("{renderBody}", content);
                    message.Subject = "Новости кондитерской Cosmic Cakes";
                    GenerateMailAttachments(attachedFiles).ToList().ForEach(attach => message.Attachments.Add(attach));
                    try
                    {
                        using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential("cosmicakesofficial@gmail.com", "nora1996NORA");
                            smtp.EnableSsl = true;
                            smtp.Send(message);
                        }
                    }
                    catch (Exception e)
                    {

                    }
                }        
            });
        }

        private IEnumerable<Attachment> GenerateMailAttachments(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var attachment in files)
            {
                if(attachment!=null)
                {
                    var contentStream = attachment.InputStream;
                    var mailAttachment = new Attachment(contentStream, attachment.FileName, attachment.ContentType);
                    yield return mailAttachment;
                }
            }
        } 
        [HttpGet]
        public ActionResult Index()
        {
            var model = new AnnounceModel
            {
                TemplateNames = _templateRepository.GetTemplateNamesOnly(),
                SubscribedUsers = _subscribtionRepository.GetAllSubscribedUsers().ToList().Count
            };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Announce(AnnounceModel model)
        {
            Task.Run(() => NotifyUsers(model.Content, model.AttachedFiles, model.SelectedTemplateName));
            return View();
        }
    }
}