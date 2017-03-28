using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Logging.Interfaces;
using CosmicCakes.Models;
using CosmicCakes.Services.EmailService;
using CosmicCakes.Services.SmsService;
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
        public FeedbackController(IFeedbackRepository feedbackRepository, IEmailSender emailSender, ISmsSender smsSender, IAppLogger logger)
            : base(logger, emailSender, smsSender)
        {
            _feedbackRepository = feedbackRepository;
        }

        private string StreamToFile(Stream inputStream, HttpPostedFileBase file)
        {
            var path = Server.MapPath("~/User_Feedback_Images/" + (Guid.NewGuid()) + file.FileName);

            WebImage img = new WebImage(file.InputStream);
            if (img.Width > 100)
                img.Resize(100, 100,true);
            img.Save(path);

            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                inputStream.CopyTo(fileStream);
                fileStream.Flush();
            }
            return path;
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
                    Email = model.Email,
                    AttachedImagePath = StreamToFile(model.AttachedImage.InputStream,model.AttachedImage)
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