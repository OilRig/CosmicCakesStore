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
        public PriceController(ICreamRepository creamRepo, IBisquitRepository bisquitRepo, IFillingRepository fillingRepo, IBerryRepository berryRepo)
        {
            _bisquitRepository = bisquitRepo;
            _berryRepository = berryRepo;
            _creamRepository = creamRepo;
            _fillingRepository = fillingRepo;
        }
        // GET: Price
        public ActionResult Index()
        {

            var priceModel = new CreateCakePageModel();
            var berries = _berryRepository.GetAll();
            var fillings = _fillingRepository.GetAll();
            var creams = _creamRepository.GetAll();
            var bisquits = _bisquitRepository.GetAll();
            foreach (var item in berries)
                priceModel.Berries.Add(item);
            return View(priceModel);
        }
        [HttpPost]
        public ActionResult Order(CreateCakePageModel model)
        {
            UpdateModel(model);
            if (ModelState.IsValid)
                return Content("Done");
            else
                return View("Index", model);
        }
    }
}