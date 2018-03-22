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
        private readonly ICakeInventoryRepository _inventoryRepository;
        public FeedbackController(ICakeInventoryRepository inventoryRepository, IEmailSender emailSender,IAppLogger logger)
            : base(logger, emailSender)
        {
            _inventoryRepository = inventoryRepository;
        }

        private string StreamToFile(Stream inputStream, HttpPostedFileBase file)
        {
            string guidFileName = (Guid.NewGuid()) + file.FileName;
            string path = Server.MapPath("/Content/Images/User_Feedback_Images/" + guidFileName);

            WebImage img = new WebImage(inputStream);
            if (img.Width > 100)
                img.Resize(300, 300, true);
            img.Save(path);
            
            return guidFileName;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                Task<UserFeedback[]> feedbacks = Task.Run(() => _inventoryRepository.GetAll<UserFeedback>());

                FeedbackItemsModel model = new FeedbackItemsModel()
                {
                    UserFeedbacks = await feedbacks
                };

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
            UserFeedback[] feedbacks = await Task.Run(() => _inventoryRepository.GetAll<UserFeedback>());

            FeedbackItemsModel infoModel = new FeedbackItemsModel()
            {
                LeftedFeedback = model,
                UserFeedbacks = feedbacks
            };

            if (ModelState.IsValid)
            {
                if(this.IsCaptchaValid(string.Empty))
                {
                    UserFeedback feedback = new UserFeedback()
                    {
                        Author = model.Author,
                        Content = model.Content,
                        CreateDate = model.CreateDate,
                        Email = model.Email,
                        AttachedImagePath = model.AttachedImage != null ? StreamToFile(model.AttachedImage.InputStream, model.AttachedImage) : null
                    };

                    await Task.Run(() => _inventoryRepository.Add(feedback));

                    return View();
                }

                ModelState.AddModelError("CAPTCHA", "Неверная капча!");

                return View("Index", infoModel);
            }
            else
            {
                return View("Index", infoModel);
            }
            
        }
    }
}