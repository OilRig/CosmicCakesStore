using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Logging.Interfaces;
using CosmicCakes.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;

namespace CosmicCakes.Controllers
{
    public class HomeController : AppServiceController
    {
        private readonly ICakeInventoryRepository _inventoryRepository;

        public HomeController( ICakeInventoryRepository inventoryRepository,
            IAppLogger logger) : base(logger)
        {
            _inventoryRepository = inventoryRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Prices()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Help()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Blog()
        {
            Task<BlogPost[]> posts = Task.Run(() => _inventoryRepository.GetAll<BlogPost>());

            BlogItemsModel model = new BlogItemsModel()
            {
                BlogPosts = await posts
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Inventory()
        {
            Task<Filling[]> fillingsTask = Task.Run(() => _inventoryRepository.GetAll<Filling>());
            Task<Bisquit[]> bisquitsTask = Task.Run(() => _inventoryRepository.GetAll<Bisquit>());
            Task<Cream[]> creamTask      = Task.Run(() => _inventoryRepository.GetAll<Cream>());

            try
            {
                CakePartsModel partsModel = new CakePartsModel
                {
                    Fillings = await fillingsTask,
                    Bisquits = await bisquitsTask,
                    Creams   = await creamTask
                };

                return View(partsModel);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Inventory/Index:{ex.Message}");
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> SendHelpRequest(HelpRequestModel model)
        {
            if (ModelState.IsValid)
            {
                if (this.IsCaptchaValid("Неверная капча!"))
                {
                    HelpRequest request = new HelpRequest()
                    {
                        Email = model.Email,
                        Name = model.Name,
                        Patronymic = model.Patronymic,
                        RequestText = model.RequestText
                    };

                    await Task.Run(() => _inventoryRepository.Add(request));

                    return View("SuccessRequest");
                }

                ModelState.AddModelError("CAPTCHA", "Неверная капча!");
            }

            return View("Help", model);
        }
    }
}