using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Logging.Interfaces;
using CosmicCakes.Models;
using CosmicCakes.Services.EmailService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;

namespace CosmicCakes.Controllers
{
    public class CakeController : AppServiceController
    {
        private readonly ICakeInventoryRepository _inventoryRepository;

        public CakeController(ICakeInventoryRepository inventoryRepository, IEmailSender emailSender, IAppLogger logger)
            : base(logger, emailSender)
        {
            _inventoryRepository        = inventoryRepository;
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
                SelectedOneLevelBisquit   = GetStringValueOrEmpty(model.SelectedOneLevelBisquit),
                Berries                   = GetStringValueOrEmpty(model.SelectedBerries)
            };

            _inventoryRepository.Add(order);
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var cakes = Task.Run(() => _inventoryRepository.GetActiveItems<SimpleReadyCake>());

                List<CakesStartPageModel> cakesList = new List<CakesStartPageModel>();

                foreach (var cake in await cakes)
                {
                    var imageTask = Task.Run(() => _inventoryRepository.GetAllWithMappingByForeignKey<SimpleCakeImage, string>(cake.Id, image => image.Path));

                    cakesList.Add(new CakesStartPageModel
                    {
                        Id                  = cake.Id,
                        Description         = cake.Description,
                        Name                = cake.Name,
                        KgPrice             = cake.KgPrice,
                        MinWeight           = cake.MinWeight,
                        MinPrice            = cake.MinPrice,
                        BackgroundImagePath = cake.BackgroundImagePath,
                        ImagePaths          = await imageTask
                    });

                    imageTask.Dispose();
                }

                return View(cakesList);
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
                var cakeTask = Task.Run(() => _inventoryRepository.GetById<SimpleReadyCake>(id));

                var individualRectangleImagesPaths = Task.Run(() => _inventoryRepository.GetAllWithMappingByForeignKey<CakeIndividualRectangleImage, string>(id, image => image.Path));

                var priceIncludements = Task.Run(() => _inventoryRepository.GetAllWithMappingByForeignKey<IndividualPriceIncludement, string>(id, includement => includement.IncludementInfo));

                var bisquits = Task.Run(() => _inventoryRepository.GetAllWithMapping<Bisquit, string>(bisquit => bisquit.Type));

                var fillings = Task.Run(() => _inventoryRepository.GetAllWithMapping<Filling, string>(filling => filling.Type));

                var berries  = await Task.Run(() => _inventoryRepository.GetAll<Berry>());
                
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
                        Fillings    = await fillings,
                        Berries     = berries.Select(berry => berry.Name),
                        CakeName    = cake.Name
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
            if (ModelState.IsValid)
            {
                model.CakeName = model.CakeName;

                await Task.Run(() => SaveOrder(model));
                Task.Run(() => EmailSender.SendEmailOrder(model.ToString()));

                return View("SuccessOrder");
            }
            else
            {
                SimpleReadyCake cake = await Task.Run(() => _inventoryRepository.GetById<SimpleReadyCake>(model.Id));

                var individualRectangleImagesPaths = Task.Run(() => _inventoryRepository.GetAllWithMappingByForeignKey<CakeIndividualRectangleImage, string>(model.Id, image => image.Path));

                var priceIncludements = Task.Run(() => _inventoryRepository.GetAllWithMappingByForeignKey<IndividualPriceIncludement, string>(model.Id, includement => includement.IncludementInfo));

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
                    CakeOrderModel = model
                };

                return View("CakeInfo", infoModel);
            }
        }
    }
}