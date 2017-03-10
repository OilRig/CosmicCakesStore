using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Models;
using CosmicCakes.Services.EmailService;
using CosmicCakes.Services.SmsService;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CosmicCakes.Logging.Interfaces;

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
            IEmailSender emailSender, ISmsSender smsSender, IAppLogger logger):base(logger,emailSender,smsSender)
        {
            _simpleCakeRepository = simpleCakeRepository;
            _imageRepository = imageRepository;
            _priceIncludementRepository = priceIncludementRepository;
            _fillingRepository = fillingRepository;
            _bisquitRepository = bisquitRepository;
            _orderRepository = orderRepo;
            _cakeRepository = cakeRepository;
            _existingCakes = new List<CakesStartPageModel>();
        }

        private void SaveOrder(OrderModel model)
        {
            var order = new Order();
            order.CakeWeight = model.CakeWeight;
            order.Comments = model.Comments;
            order.CustomerName = model.CustomerName;
            order.CustomerPhoneNumber = model.CustomerPhoneNumber;
            order.ExpireDate = model.ExpireDate;
            order.OrderDate = DateTime.Now;
            order.CakeName = model.CakeName;
            _orderRepository.Add(order);
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var cakes = _simpleCakeRepository.GetExistingCakes();
                foreach (var cake in cakes)
                {
                    _existingCakes.Add(new CakesStartPageModel
                    {
                        Id = cake.Id,
                        Description = cake.Description,
                        Name = cake.Name,
                        KgPrice = cake.KgPrice,
                        MinWeight = cake.MinWeight,
                        MinPrice = cake.MinPrice,
                        BackgroundImagePath = cake.BackgroundImagePath,
                        ImagePaths = _imageRepository.GetAllImagePathsByCakeId(cake.Id)
                    });
                }
                return View(_existingCakes);
            }
            catch (Exception ex)
            {
                Logger.Error(ex,$"Cake/Index:{ex.Message}");
                return View("Error");
            }
            
        }

        [HttpGet]
        public ActionResult CakeInfo(int id)
        {
            try
            {
                var cake = _simpleCakeRepository.GetCakeById(id);
                var infoModel = new CakeInfoModel
                {
                    Name = cake.Name,
                    KgPrice = cake.KgPrice,
                    MinWeight = cake.MinWeight,
                    MinPrice = cake.MinPrice,
                    Description = cake.Description,
                    IsLevelable = cake.IsLevelable,
                    MaxWeight = cake.MaxWeight,
                    IndividualRectangleImagesPaths = _imageRepository.GetCakeIndividualRectangleImagesByCakeId(cake.Id),
                    PriceIncludements = _priceIncludementRepository.GetAllPriceIncludementsById(id),
                    Id = cake.Id,
                    CakeOrderModel = new OrderModel()
                    {
                        Id = cake.Id
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
        public ActionResult MakeOrder(OrderModel model)
        {
            model.CakeName = _cakeRepository.GetCakeById(model.Id).Name;
            if (ModelState.IsValid)
            {
                UpdateModel(model);
                SaveOrder(model);
                EmailSender.SendEmailOrder(model.ToString());
                SmsSender.SendSmsOrder(model.ToString());
                return View("SuccessOrder");
            }
            else
            {
                var cake = _simpleCakeRepository.GetCakeById(model.Id);
                var infoModel = new CakeInfoModel
                {
                    Name = cake.Name,
                    KgPrice = cake.KgPrice,
                    MinWeight = cake.MinWeight,
                    MinPrice = cake.MinPrice,
                    Description = cake.Description,
                    IsLevelable = cake.IsLevelable,
                    MaxWeight = cake.MaxWeight,
                    IndividualRectangleImagesPaths = _imageRepository.GetCakeIndividualRectangleImagesByCakeId(cake.Id),
                    PriceIncludements = _priceIncludementRepository.GetAllPriceIncludementsById(model.Id),
                    Id = cake.Id,
                    CakeOrderModel = model
                };
                ModelState.AddModelError(string.Empty,"Не все обязательные поля были заполнены");
                return View("CakeInfo", infoModel);
            }
        }
    }
}