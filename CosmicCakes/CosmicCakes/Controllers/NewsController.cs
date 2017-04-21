using CosmicCakes.DAL.Interfaces;
using CosmicCakes.DAL.Entities;
using CosmicCakes.Logging.Interfaces;
using CosmicCakes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CosmicCakes.Controllers
{
    public class NewsController : AppServiceController
    {
        private readonly IUserSubscriptionRepository _subscriptionRepository;
        public NewsController(IAppLogger logger,IUserSubscriptionRepository subsRepo) : base(logger)
        {
            _subscriptionRepository = subsRepo;
        }

        private void SaveUserSubscription(NewsSubscribeModel userInfo)
        {
            var userSubscription = new UserSubscribtion
            {
                Email = userInfo.Email,
                Name = userInfo.Name,
                Patronymic = userInfo.Patronymic
            };

            _subscriptionRepository.Add(userSubscription);
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubscribeForNews(NewsSubscribeModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    TryValidateModel(model);
                    SaveUserSubscription(model);
                    return View("SubscribeCompleted");
                }
                catch(Exception)
                {
                    return View("Index",model);
                }
            }
            return View("Index", model);
        }
    }
}