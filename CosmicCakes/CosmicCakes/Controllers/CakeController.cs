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
using CosmicCakes.DAL.Entities.Sweets;

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
        public async Task<ActionResult> Index()
        {
            try
            {
                var cakes = Task.Run(() => _inventoryRepository.GetActiveItems<SimpleReadyCake>());

                List<CakesStartPageModel> cakesList = new List<CakesStartPageModel>();

                foreach (var cake in await cakes)
                {
                    Task<string[]> imageTask = Task.Run(() => _inventoryRepository.GetAllWithMappingByForeignKey<SimpleCakeImage, string>(cake.Id, image => image.Path));

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
                Task<SimpleReadyCake> cakeTask = Task.Run(() => _inventoryRepository.GetById<SimpleReadyCake>(id));

                Task<string[]> individualRectangleImagesPaths = Task.Run(() => _inventoryRepository.GetAllWithMappingByForeignKey<CakeIndividualRectangleImage, string>(id, image => image.Path));

                Task<string[]> priceIncludements = Task.Run(() => _inventoryRepository.GetAllWithMappingByForeignKey<IndividualPriceIncludement, string>(id, includement => includement.IncludementInfo));

                Task<string[]> bisquits = Task.Run(() => _inventoryRepository.GetAllWithMapping<Bisquit, string>(bisquit => bisquit.Type));

                Task<string[]> fillings = Task.Run(() => _inventoryRepository.GetAllWithMapping<Filling, string>(filling => filling.Type));

                Berry[] berries  = await Task.Run(() => _inventoryRepository.GetAll<Berry>());
                
                SimpleReadyCake cake = await cakeTask;

                CakeInfoModel infoModel = new CakeInfoModel
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

        [HttpGet]
        public async Task<ActionResult> Sweets()
        {
            Task<AdditionalSweet[]> sweets = Task.Run(() => _inventoryRepository.GetAll<AdditionalSweet>());

            List<SweetModel> sweetsLoist = new List<SweetModel>();

            foreach(var sweet in await sweets)
            {
                sweetsLoist.Add(new SweetModel()
                {
                    Id = sweets.Id,
                    Title = sweet.Title,
                    Description = sweet.Description,
                    StartPricePerPcs = sweet.StartPricePerPcs
                });
            }

            SweetsAggregatedModel model = new SweetsAggregatedModel()
            {
                Sweets = sweetsLoist.ToArray()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Sweet(int sweetId)
        {
            return null;
        }

        [HttpGet]
        public async Task<ActionResult> FastOrder()
        {
            Task<SimpleReadyCake[]> cakeTask = Task.Run(() => _inventoryRepository.GetAll<SimpleReadyCake>());

            Task<string[]> bisquits = Task.Run(() => _inventoryRepository.GetAllWithMapping<Bisquit, string>(bisquit => bisquit.Type));

            Task<string[]> fillings = Task.Run(() => _inventoryRepository.GetAllWithMapping<Filling, string>(filling => filling.Type));

            Berry[] berries = await Task.Run(() => _inventoryRepository.GetAll<Berry>());

            SimpleReadyCake[] cakes = await cakeTask;

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