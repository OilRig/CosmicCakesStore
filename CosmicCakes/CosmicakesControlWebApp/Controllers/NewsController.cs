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

namespace CosmicakesControlWebApp.Controllers
{
    public class NewsController : Controller
    {
        IUserSubscriptionRepository _subscribtionRepository;
        public NewsController(IUserSubscriptionRepository subscribtionRepository)
        {
            _subscribtionRepository = subscribtionRepository;
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
        private void NotifyUsers(IEnumerable<UserSubscribtion> subsUsers,string content)
        {
            subsUsers
                .ToList()
                .ForEach(u =>
            {
                var from = new MailAddress("cosmicakesofficial@gmail.com","Кондитерская Cosmic Cakes");
                var to = new MailAddress(u.Email);

                var message = new MailMessage(from, to);                
                message.Body = $"Уважаемый(ая) {u.Name} {u.Patronymic}! \n Вас приветствует Нора Голубева из кондитерской Cosmic Cakes! У нас для Вас есть новости. \n \n {content}";
                message.Subject = "Новости кондитерской Cosmic Cakes";
                SendMessageAsync(message); 
            });
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Announce(AnnounceModel model)
        {
            var users = _subscribtionRepository.GetAllSubscribedUsers();
            NotifyUsers(users,model.Content);
            return View();
        }
    }
}