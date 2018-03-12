using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Logging.Interfaces;
using CosmicCakes.Models;
using CosmicCakes.Services.EmailService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Xsl;
using CaptchaMvc.HtmlHelpers;

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

        private void FillFeedbacks(IEnumerable<UserFeedback> feedbacks, UserFeedbackModel userFeedback, FeedbackItemsModel model )
        {
            foreach (var feedback in feedbacks)
                model.UserFeedbacks.Add(feedback);

            model.LeftedFeedback = userFeedback;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var model = new FeedbackItemsModel();
                var feedbacks = await Task.Run(() => _feedbackRepository.GetAllFeedbacks());
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
        public async Task<ActionResult> SaveFeedback(UserFeedbackModel model)
        {
            var feedbacks = await Task.Run(() => _feedbackRepository.GetAllFeedbacks());
            var infoModel = new FeedbackItemsModel();

            if (ModelState.IsValid)
            {
                if(this.IsCaptchaValid(string.Empty))
                {
                    var feedback = new UserFeedback()
                    {
                        Author = model.Author,
                        Content = model.Content,
                        CreateDate = model.CreateDate,
                        Email = model.Email,
                        AttachedImagePath = model.AttachedImage != null ? StreamToFile(model.AttachedImage.InputStream, model.AttachedImage) : null
                    };

                    await Task.Run(() => _feedbackRepository.Add(feedback));

                    return View();
                }

                ModelState.AddModelError("CAPTCHA", "Неверная капча!");

                FillFeedbacks(feedbacks, model, infoModel);

                return View("Index", infoModel);
            }
            else
            {
                FillFeedbacks(feedbacks, model, infoModel);

                return View("Index", infoModel);
            }
            
        }
    }
}