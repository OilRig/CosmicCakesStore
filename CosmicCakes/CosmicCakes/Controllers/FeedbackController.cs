using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CosmicCakes.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new FeedbackItemsModel();
            var feedbacks = _feedbackRepository.GetAllFeedbacks();
            foreach (var feedback in feedbacks)
                model.UserFeedbacks.Add(feedback);
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveFeedback(UserFeedbackModel model)
        {
            var feedback = new UserFeedback()
            {
                Author = model.Author,
                Content = model.Content,
                CreateDate = model.CreateDate
            };
            _feedbackRepository.Add(feedback);
            return View();
        }
    }
}