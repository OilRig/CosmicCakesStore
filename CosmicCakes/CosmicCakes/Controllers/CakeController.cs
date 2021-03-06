﻿using CosmicCakes.DAL.Entities;
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
            order.ExpireDate = DateTime.ParseExact(model.ExpireDateString, "MM/dd/yyyy", null);
            order.OrderDate = DateTime.Now;
            order.CakeName = model.CakeName;
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
                Logger.Error(ex, $"Cake/Index:{ex.Message}");
                return View("Error");
            }

        }

        [HttpGet]
        public async Task<ActionResult> CakeInfo(int id)
        {
            try
            {
                var cake = await Task.Run(() => _simpleCakeRepository.GetCakeById(id));
                var individualRectangleImagesPaths = await Task.Run(() => _imageRepository.GetCakeIndividualRectangleImagesByCakeId(cake.Id));
                var priceIncludements = await Task.Run(() => _priceIncludementRepository.GetAllPriceIncludementsById(cake.Id));

                var infoModel = new CakeInfoModel
                {
                    Name = cake.Name,
                    KgPrice = cake.KgPrice,
                    MinWeight = cake.MinWeight,
                    MinPrice = cake.MinPrice,
                    Description = cake.Description,
                    MainInfo = cake.MainInfo,
                    IsLevelable = cake.IsLevelable,
                    MaxWeight = cake.MaxWeight,
                    IndividualRectangleImagesPaths = individualRectangleImagesPaths,
                    PriceIncludements = priceIncludements,
                    Id = cake.Id,
                    CakeOrderModel = new OrderModel()
                    {
                        Id = cake.Id,
                        IsLevelable = cake.IsLevelable,
                        Bisquits = await Task.Run(() => _bisquitRepository.GetAllNamesOnly()),
                        Fillings = await Task.Run(() => _fillingRepository.GetAllNamesOnly())
                    },

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
            model.CakeName = await Task.Run(() => _cakeRepository.GetCakeById(model.Id).Name);
            if (ModelState.IsValid)
            {
                UpdateModel(model);
                Task.Run(() => SaveOrder(model));
                Task.Run(() => EmailSender.SendEmailOrder(model.ToString()));
                return View("SuccessOrder");
            }
            else
            {
                var cake = await Task.Run(() => _simpleCakeRepository.GetCakeById(model.Id));
                var individualRectangleImagesPaths = await Task.Run(() => _imageRepository.GetCakeIndividualRectangleImagesByCakeId(cake.Id));
                var priceIncludements = await Task.Run(() => _priceIncludementRepository.GetAllPriceIncludementsById(cake.Id));
                var infoModel = new CakeInfoModel
                {
                    Name = cake.Name,
                    KgPrice = cake.KgPrice,
                    MinWeight = cake.MinWeight,
                    MinPrice = cake.MinPrice,
                    Description = cake.Description,
                    MainInfo = cake.MainInfo,
                    IsLevelable = cake.IsLevelable,
                    MaxWeight = cake.MaxWeight,
                    IndividualRectangleImagesPaths = individualRectangleImagesPaths,
                    PriceIncludements = priceIncludements,
                    Id = cake.Id,
                    CakeOrderModel = new OrderModel()
                    {
                        Id = cake.Id,
                        IsLevelable = cake.IsLevelable,
                        Bisquits = await Task.Run(() => _bisquitRepository.GetAllNamesOnly()),
                        Fillings = await Task.Run(() => _fillingRepository.GetAllNamesOnly())
                    }
                };
                return View("CakeInfo", infoModel);
            }
        }
    }
}