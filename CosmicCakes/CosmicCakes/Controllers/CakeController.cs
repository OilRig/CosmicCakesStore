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
using CosmicCakes.DAL.Entities.Images;
using CosmicCakes.DAL.Entities.Pricing;
using CosmicCakes.DAL.Entities.Inventory;
using CosmicCakes.DAL.Entities.Order;

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
            Order order = new Order()
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
        public async Task<ActionResult> Cakes()
        {
            try
            {
                var cakes = Task.Run(() => _inventoryRepository.GetActiveCakeItems<CommonSweet>());

                List<CakesStartPageModel> cakesList = new List<CakesStartPageModel>();

                foreach (var cake in await cakes)
                {
                    Task<string[]> imageTask = Task.Run(() => _inventoryRepository.GetAllWithMappingByForeignKey<SweetImage, string>(cake.Id, image => image.Path));

                    cakesList.Add(new CakesStartPageModel
                    {
                        Id                  = cake.Id,
                        Description         = cake.Description,
                        Name                = cake.Name,
                        KgPrice             = cake.PricePerKilo,
                        MinWeight           = cake.MinWeight,
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
                Task<CommonSweet> cakeTask = Task.Run(() => _inventoryRepository.GetById<CommonSweet>(id));

                Task<string[]> individualRectangleImagesPaths = Task.Run(() => _inventoryRepository.GetAllWithMappingByForeignKey<SweetIndividualRectangleImage, string>(id, image => image.Path));

                Task<string[]> priceIncludements = Task.Run(() => _inventoryRepository.GetAllWithMappingByForeignKey<IndividualPriceIncludement, string>(id, includement => includement.IncludementInfo));

                Task<string[]> bisquits = Task.Run(() => _inventoryRepository.GetAllWithMapping<Bisquit, string>(bisquit => bisquit.Type));

                Task<string[]> fillings = Task.Run(() => _inventoryRepository.GetAllWithMapping<Filling, string>(filling => filling.Type));

                Berry[] berries  = await Task.Run(() => _inventoryRepository.GetAll<Berry>());
                
                CommonSweet cake = await cakeTask;

                CakeInfoModel infoModel = new CakeInfoModel
                {
                    Name                           = cake.Name,
                    KgPrice                        = cake.PricePerKilo,
                    MinWeight                      = cake.MinWeight,
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
                        Berries     = berries.Select(berry => berry.Name).ToArray(),
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
                CommonSweet cake = await Task.Run(() => _inventoryRepository.GetById<CommonSweet>(model.Id));

                var individualRectangleImagesPaths = Task.Run(() => _inventoryRepository.GetAllWithMappingByForeignKey<SweetIndividualRectangleImage, string>(model.Id, image => image.Path));

                var priceIncludements = Task.Run(() => _inventoryRepository.GetAllWithMappingByForeignKey<IndividualPriceIncludement, string>(model.Id, includement => includement.IncludementInfo));

                var infoModel = new CakeInfoModel
                {
                    Name                           = cake.Name,
                    KgPrice                        = cake.PricePerKilo,
                    MinWeight                      = cake.MinWeight,
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

        [HttpGet]
        public async Task<ActionResult> Sweets()
        {
            Task<CommonSweet[]> sweets = Task.Run(() => _inventoryRepository.GetActiveSweetItems<CommonSweet>());

            List<SweetModel> sweetsLoist = new List<SweetModel>();

            foreach(var sweet in await sweets)
            {
                Task<string[]> imageTask = Task.Run(() => _inventoryRepository.GetAllWithMappingByForeignKey<SweetImage, string>(sweet.Id, image => image.Path));

                sweetsLoist.Add(new SweetModel()
                {
                    Id               = sweet.Id,
                    Title            = sweet.Name,
                    Description      = sweet.Description,
                    StartPricePerPcs = sweet.PricePerItem,
                    ImagePaths       = await imageTask
                });
            }

            SweetsAggregatedModel model = new SweetsAggregatedModel()
            {
                Sweets = sweetsLoist.ToArray()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> SweetInfo(int sweetId)
        {
            try
            {
                Task<CommonSweet> cakeTask = Task.Run(() => _inventoryRepository.GetById<CommonSweet>(sweetId));

                Task<string[]> individualRectangleImagesPaths = Task.Run(() => _inventoryRepository.GetAllWithMappingByForeignKey<SweetIndividualRectangleImage, string>(sweetId, image => image.Path));

                Task<string[]> priceIncludements = Task.Run(() => _inventoryRepository.GetAllWithMappingByForeignKey<IndividualPriceIncludement, string>(sweetId, includement => includement.IncludementInfo));

                Task<string[]> bisquits = Task.Run(() => _inventoryRepository.GetAllWithMapping<Bisquit, string>(bisquit => bisquit.Type));

                Task<string[]> fillings = Task.Run(() => _inventoryRepository.GetAllWithMapping<Filling, string>(filling => filling.Type));

                Berry[] berries = await Task.Run(() => _inventoryRepository.GetAll<Berry>());

                CommonSweet cake = await cakeTask;

                SweetInfoModel infoModel = new SweetInfoModel
                {
                    Name = cake.Name,
                    Info = cake.MainInfo,
                    IndividualRectangleImagesPaths = await individualRectangleImagesPaths,
                    PriceIncludements = await priceIncludements,
                    Id = cake.Id,
                    CakeOrderModel = new OrderModel()
                    {
                        Id          = cake.Id,
                        IsLevelable = cake.IsLevelable,
                        Bisquits    = await bisquits,
                        Fillings    = await fillings,
                        Berries     = berries.Select(berry => berry.Name).ToArray(),
                        CakeName    = cake.Name,
                        IsCake      = cake.IsCake,
                        IsSweet     = cake.IsAdditionalSweet
                    },
                    MinPcsCount = cake.MinOrderItemsCount,
                    PricePerPcs = cake.PricePerItem
                };

                return View(infoModel);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Cake/CakeInfo:Id {sweetId}");
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> FastOrder()
        {
            Task<CommonSweet[]> cakeTask = Task.Run(() => _inventoryRepository.GetAll<CommonSweet>());

            Task<string[]> bisquits = Task.Run(() => _inventoryRepository.GetAllWithMapping<Bisquit, string>(bisquit => bisquit.Type));

            Task<string[]> fillings = Task.Run(() => _inventoryRepository.GetAllWithMapping<Filling, string>(filling => filling.Type));

            Berry[] berries = await Task.Run(() => _inventoryRepository.GetAll<Berry>());

            CommonSweet[] cakes = await cakeTask;

            Models.OrderModel model = new OrderModel()
            {
                Bisquits = await bisquits,
                Fillings = await fillings,
                Cakes = cakes.Select(c => c.Name).ToArray(),
                Berries = berries.Select(berry => berry.Name).ToArray()
            };

            return View(model);
        }
    }
}