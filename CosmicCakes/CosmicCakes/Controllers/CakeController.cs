using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Logging.Interfaces;
using CosmicCakes.Models;
using CosmicCakes.Services.EmailService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CosmicCakes.Controllers
{
    public class CakeController : AppServiceController
    {
        private readonly ISimpleCakeRepository _simpleCakeRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IPriceIncludementRepository _priceIncludementRepository;
        private readonly IFillingRepository _fillingRepository;
        private readonly IBisquitRepository _bisquitRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ISimpleCakeRepository _cakeRepository;

        private readonly List<CakesStartPageModel> _existingCakes;

        public CakeController(ISimpleCakeRepository simpleCakeRepository, IImageRepository imageRepository,
            IPriceIncludementRepository priceIncludementRepository, IFillingRepository fillingRepository,
            IBisquitRepository bisquitRepository, IOrderRepository orderRepo, ISimpleCakeRepository cakeRepository,
            IEmailSender emailSender, IAppLogger logger) : base(logger, emailSender)
        {
            _simpleCakeRepository       = simpleCakeRepository;
            _imageRepository            = imageRepository;
            _priceIncludementRepository = priceIncludementRepository;
            _fillingRepository          = fillingRepository;
            _bisquitRepository          = bisquitRepository;
            _orderRepository            = orderRepo;
            _cakeRepository             = cakeRepository;
            _existingCakes              = new List<CakesStartPageModel>();
        }

        private string GetStringValueOrEmpty(string value) => value ?? string.Empty;

        private void SaveOrder(OrderModel model)
        {
            var order = new Order()
            {
                CakeName                  = GetStringValueOrEmpty(model.CakeName),
                CakeWeight                = model.CakeWeight,
                Comments                  = GetStringValueOrEmpty(model.Comments),
                CustomerName              = GetStringValueOrEmpty(model.CustomerName),
                CustomerPhoneNumber       = GetStringValueOrEmpty(model.CustomerPhoneNumber),
                DeliveryNeeded            = model.DeliveryNeeded,
                DeliveryAdress            = GetStringValueOrEmpty(model.DeliveryAdress),
                ExpireDate                = DateTime.ParseExact(model.ExpireDateString, "MM/dd/yyyy", null),
                OrderDate                 = DateTime.UtcNow,
                SelectedLevels            = model.SelectedLevels,
                FillingType               = GetStringValueOrEmpty(model.SelectedFilling),
                FirstLevelBisquit         = GetStringValueOrEmpty(model.FirstLevelBisquit),
                SecondLevelBisquit        = GetStringValueOrEmpty(model.SecondLevelBisquit),
                ThirdLevelBisquit         = GetStringValueOrEmpty(model.ThirdLevelBisquit),
                SelectedMultiLevelBisquit = GetStringValueOrEmpty(model.SelectedMultiLevelBisquit),
                SelectedOneLevelBisquit   = GetStringValueOrEmpty(model.SelectedOneLevelBisquit)
            };
            _orderRepository.Add(order);
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var cakes = await Task.Run(()=>_simpleCakeRepository.GetExistingCakes());

                foreach (var cake in cakes)
                {
                    _existingCakes.Add(new CakesStartPageModel
                    {
                        Id                  = cake.Id,
                        Description         = cake.Description,
                        Name                = cake.Name,
                        KgPrice             = cake.KgPrice,
                        MinWeight           = cake.MinWeight,
                        MinPrice            = cake.MinPrice,
                        BackgroundImagePath = cake.BackgroundImagePath,
                        ImagePaths          = _imageRepository.GetAllImagePathsByCakeId(cake.Id)
                    });
                }

                return View(_existingCakes);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Cake/Index:{ex.Message}");
                return View("Error");
            }

        }

        [HttpGet]
        public async Task<ActionResult> CakeInfo(int id)
        {
            try
            {
                var cakeTask = Task.Run(() => _simpleCakeRepository.GetCakeById(id));

                var individualRectangleImagesPaths = Task.Run(() => _imageRepository.GetCakeIndividualRectangleImagesByCakeId(id));
                var priceIncludements = Task.Run(() => _priceIncludementRepository.GetAllPriceIncludementsById(id));

                var bisquits = Task.Run(() => _bisquitRepository.GetAllNamesOnly());
                var fillings = Task.Run(() => _fillingRepository.GetAllNamesOnly());

                var cake = await cakeTask;

                var infoModel = new CakeInfoModel
                {
                    Name                           = cake.Name,
                    KgPrice                        = cake.KgPrice,
                    MinWeight                      = cake.MinWeight,
                    MinPrice                       = cake.MinPrice,
                    Description                    = cake.Description,
                    MainInfo                       = cake.MainInfo,
                    IsLevelable                    = cake.IsLevelable,
                    MaxWeight                      = cake.MaxWeight,
                    IndividualRectangleImagesPaths = await individualRectangleImagesPaths,
                    PriceIncludements              = await priceIncludements,
                    Id                             = cake.Id,
                    CakeOrderModel = new OrderModel()
                    {
                        Id          = cake.Id,
                        IsLevelable = cake.IsLevelable,
                        Bisquits    = await bisquits,
                        Fillings    = await fillings
                    }
                };

                return View(infoModel);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Cake/CakeInfo:Id {id}");
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> MakeOrder(OrderModel model)
        {
            SimpleReadyCake cake = await Task.Run(() => _simpleCakeRepository.GetCakeById(model.Id));

            if (ModelState.IsValid)
            {
                model.CakeName = cake.Name;

                await Task.Run(() => SaveOrder(model));
                await Task.Run(() => EmailSender.SendEmailOrder(model.ToString()));

                return View("SuccessOrder");
            }
            else
            {
                var individualRectangleImagesPaths = Task.Run(() => _imageRepository.GetCakeIndividualRectangleImagesByCakeId(model.Id));
                var priceIncludements = Task.Run(() => _priceIncludementRepository.GetAllPriceIncludementsById(model.Id));

                var bisquits = Task.Run(() => _bisquitRepository.GetAllNamesOnly());
                var fillings = Task.Run(() => _fillingRepository.GetAllNamesOnly());

                var infoModel = new CakeInfoModel
                {
                    Name                           = cake.Name,
                    KgPrice                        = cake.KgPrice,
                    MinWeight                      = cake.MinWeight,
                    MinPrice                       = cake.MinPrice,
                    Description                    = cake.Description,
                    MainInfo                       = cake.MainInfo,
                    IsLevelable                    = cake.IsLevelable,
                    MaxWeight                      = cake.MaxWeight,
                    IndividualRectangleImagesPaths = await individualRectangleImagesPaths,
                    PriceIncludements              = await priceIncludements,
                    Id                             = cake.Id,
                    CakeOrderModel = new OrderModel()
                    {
                        Id          = cake.Id,
                        IsLevelable = cake.IsLevelable,
                        Bisquits    = await bisquits,
                        Fillings    = await fillings
                    }
                };

                return View("CakeInfo", infoModel);
            }
        }
    }
}