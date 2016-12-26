using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Models;
using System.Web.Mvc;

namespace CosmicCakes.Controllers
{
    public class PriceController : Controller
    {
        private readonly IBisquitRepository _bisquitRepository;
        private readonly IFillingRepository _fillingRepository;
        private readonly IBerryRepository _berryRepository;
        private readonly ICreamRepository _creamRepository;
        private CreateCakePageModel CreatePageContent()
        {
            var priceModel = new CreateCakePageModel();
            var berries = _berryRepository.GetAll();
            var fillings = _fillingRepository.GetAll();
            var creams = _creamRepository.GetAll();
            var bisquits = _bisquitRepository.GetAll();
            foreach (var item in berries)
                priceModel.Berries.Add(item);
            foreach (var item in fillings)
                priceModel.Filling.Add(item);
            foreach (var item in creams)
                priceModel.Cream.Add(item);
            foreach (var item in bisquits)
                priceModel.Bisquit.Add(item);
            return priceModel;
        }
        private OrderModel MakeOrder(CreateCakePageModel model)
        {
            var orderModel = new OrderModel();
            orderModel.BisquitType = model.BisquitType;
            orderModel.CakeWeight = model.CakeWeight;
            orderModel.Comments = model.Comments;
            orderModel.FillingType = model.FillingType;
            orderModel.Berries = model.SelectedBerries;
            return orderModel;
        }
        public PriceController(ICreamRepository creamRepo, IBisquitRepository bisquitRepo,
            IFillingRepository fillingRepo, IBerryRepository berryRepo)
        {
            _bisquitRepository = bisquitRepo;
            _berryRepository = berryRepo;
            _creamRepository = creamRepo;
            _fillingRepository = fillingRepo;
        }
        // GET: Price
        public ActionResult Index()
        {
            return View(CreatePageContent());
        }

        [HttpPost]
        public ActionResult Order(CreateCakePageModel model)
        {

            if (ModelState.IsValid)
            {
                return View(MakeOrder(model));
            }
            else
            {
                return Content("Fail");
            }

        }
    }
}