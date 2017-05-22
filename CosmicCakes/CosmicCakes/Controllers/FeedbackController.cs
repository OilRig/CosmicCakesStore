using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Logging.Interfaces;
using CosmicCakes.Models;
using CosmicCakes.Services.EmailService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Xsl;

namespace CosmicCakes.Controllers
{
    public class FeedbackController : AppServiceController
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackController(IFeedbackRepository feedbackRepository, IEmailSender emailSender,IAppLogger logger)
            : base(logger, emailSender)
        {
            _feedbackRepository = feedbackRepository;
        }

        private string StreamToFile(Stream inputStream, HttpPostedFileBase file)
        {
            var guidFileName = (Guid.NewGuid()) + file.FileName;
            var path = Server.MapPath("/Content/Images/User_Feedback_Images/" + guidFileName);

            WebImage img = new WebImage(inputStream);
            if (img.Width > 100)
                img.Resize(300, 300, true);
            img.Save(path);
            
            return guidFileName;
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
                return View("Error");
            }

        }

        [HttpPost]
        public ActionResult SaveFeedback(UserFeedbackModel model)
        {
            if(ModelState.IsValid)
            {
                var feedback = new UserFeedback()
                {
                    Author = model.Author,
                    Content = model.Content,
                    CreateDate = model.CreateDate,
                    Email = model.Email,
                    AttachedImagePath = model.AttachedImage != null ? StreamToFile(model.AttachedImage.InputStream, model.AttachedImage) : null
                };
                _feedbackRepository.Add(feedback);
                return View();
            }
            else
            {
                var infoModel = new FeedbackItemsModel();

                var feedbacks = _feedbackRepository.GetAllFeedbacks();

                foreach (var feedback in feedbacks)
                    infoModel.UserFeedbacks.Add(feedback);
                infoModel.LeftedFeedback = model;
                return View("Index",infoModel);
            }
            
        }
    }
}