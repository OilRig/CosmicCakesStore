using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace CosmicCakes.Controllers
{
    public class CakeController : Controller
    {
        private readonly ISimpleCakeRepository _simpleCakeRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IPriceIncludementRepository _priceIncludementRepository;
        private readonly IFillingRepository _fillingRepository;
        private readonly IBisquitRepository _bisquitRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ISimpleCakeRepository _cakeRepository;

        private List<CakesStartPageModel> _existingCakes;
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
        private void SendOrder(string order)
        {
            var from = new MailAddress("cosmicakesofficial@gmail.com", "Order");

            var to = new MailAddress("golubevanora1@gmail.com");

            using (var m = new MailMessage(from, to))
            {
                m.Subject = "Заказ";
                m.Body = order;

                var smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("cosmicakesofficial@gmail.com", "gbczgjgf2345");
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
        }

        public CakeController(ISimpleCakeRepository simpleCakeRepository, IImageRepository imageRepository,
            IPriceIncludementRepository priceIncludementRepository, IFillingRepository fillingRepository,
            IBisquitRepository bisquitRepository, IOrderRepository orderRepo, ISimpleCakeRepository cakeRepository)
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

        // GET: Cake
        [HttpGet]
        public ActionResult Index()
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

        [HttpGet]
        public ActionResult CakeInfo(int id)
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

        [HttpPost]
        public ActionResult MakeOrder(OrderModel model)
        {
            try
            {
                UpdateModel(model);
                model.ExpireDate = model.ExpireDate.ToUniversalTime();
                model.CakeName = _cakeRepository.GetCakeById(model.Id).Name;
                SaveOrder(model);
                //SendOrder(model.ToString());
                return View();
            }
            catch (Exception)
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
                return View("CakeInfo", infoModel);
            }
        }
    }
}