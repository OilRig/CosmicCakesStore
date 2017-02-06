using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Models;
using System.Web.Mvc;

namespace CosmicCakes.Controllers
{
    public class CakePartController : Controller
    {
        private readonly IFillingRepository _fillingRepository;
        private readonly IBisquitRepository _bisquitRepository;
        private readonly ICreamRepository _creamRepository;
        public CakePartController(IFillingRepository fillingRepository, IBisquitRepository bisquitRepository, ICreamRepository creamRepository)
        {
            _fillingRepository = fillingRepository;
            _bisquitRepository = bisquitRepository;
            _creamRepository = creamRepository;
        }
        // GET: CakePart
        public ActionResult Index()
        {
            var partsModel = new CakePartsModel
            {
                Fillings = _fillingRepository.GetAll(),
                Bisquits = _bisquitRepository.GetAll(),
                Creams = _creamRepository.GetAll()
            };

            return View(partsModel);
        }
    }
}