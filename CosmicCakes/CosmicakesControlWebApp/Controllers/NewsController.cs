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

        private delegate void AsyncMethodCaller(MailMessage message);
        private void SendMailInSeperateThread(MailMessage message)
        {
            try
            {
                using (message)
                {
                    var smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new NetworkCredential("cosmicakesofficial@gmail.com", "gbczgjgf2345");
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                }    
            }
            catch (Exception e)
            {
                
            }
        }
        private void AsyncCallback(IAsyncResult ar)
        {
            AsyncResult result = (AsyncResult)ar;
            AsyncMethodCaller caller = (AsyncMethodCaller)result.AsyncDelegate;
            caller.EndInvoke(ar);
        }
        private void SendMessageAsync(MailMessage message)
        {
            AsyncMethodCaller caller = new AsyncMethodCaller(SendMailInSeperateThread);
            AsyncCallback callbackHandler = new AsyncCallback(AsyncCallback);
            caller.BeginInvoke(message, callbackHandler, null);
        }
        private void NotifyUsers(IEnumerable<UserSubscribtion> subsUsers,string content,IEnumerable<HttpPostedFileBase> attachedFiles, string templateName = "CC-News")
        {
            string messageTemplate = _templateRepository.GetTemplateByName(templateName).Body;

            subsUsers
                .ToList()
                .ForEach(u =>
            {
                var from = new MailAddress("cosmicakesofficial@gmail.com","Кондитерская Cosmic Cakes");
                var to = new MailAddress(u.Email);

                var message = new MailMessage(from, to);
                message.IsBodyHtml = true;
                message.Body = messageTemplate.Replace("{firstName}",u.Name).Replace("{patronymic}",u.Patronymic).Replace("{renderBody}",content);
                message.Subject = "Новости кондитерской Cosmic Cakes";
                GenerateMailAttachments(attachedFiles).ToList().ForEach(attach=>message.Attachments.Add(attach));
                SendMessageAsync(message); 
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
                TemplateNames = _templateRepository.GetTemplateNamesOnly()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Announce(AnnounceModel model)
        {
            var users = _subscribtionRepository.GetAllSubscribedUsers();
            NotifyUsers(users,model.Content,model.AttachedFiles, model.SelectedTemplateName);
            return View();
        }
    }
}