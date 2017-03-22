using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Logging.Interfaces;
using CosmicCakes.Models;
using CosmicCakes.Services.EmailService;
using CosmicCakes.Services.SmsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CosmicCakes.Controllers
{
    public class FeedbackController : AppServiceController
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackController(IFeedbackRepository feedbackRepository, IEmailSender emailSender, ISmsSender smsSender, IAppLogger logger)
            : base(logger, emailSender, smsSender)
        {
            _feedbackRepository = feedbackRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var model = new FeedbackItemsModel();
                var feedbacks = _feedbackRepository.GetAllFeedbacks();
                foreach (var feedback in feedbacks)
                    model.UserFeedbacks.Add(feedback);
                return View(model);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Feedback/Index:{ex.Message}");
                SmsSender.SendSmsOrder(ex.Message, true);
                return View("Error");
            }

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveFeedback(UserFeedbackModel model)
        {
            if(ModelState.IsValid)
            {
                var feedback = new UserFeedback()
                {
                    Author = model.Author,
                    Content = model.Content,
                    CreateDate = model.CreateDate,
                    Email = model.Email
                };
                _feedbackRepository.Add(feedback);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index", model);
            }
            
        }
    }
}