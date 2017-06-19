using System;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Models;
using System.Web.Mvc;
using CosmicCakes.Logging.Interfaces;
using System.Threading.Tasks;

namespace CosmicCakes.Controllers
{
    public class CakePartController : AppServiceController
    {
        private readonly IFillingRepository _fillingRepository;
        private readonly IBisquitRepository _bisquitRepository;
        private readonly ICreamRepository _creamRepository;
        public CakePartController(IFillingRepository fillingRepository, IBisquitRepository bisquitRepository, ICreamRepository creamRepository,
            IAppLogger logger):base(logger)
        {
            _fillingRepository = fillingRepository;
            _bisquitRepository = bisquitRepository;
            _creamRepository = creamRepository;
        }
        // GET: CakePart
        public async Task<ActionResult> Index()
        {
            try
            {
                var partsModel = new CakePartsModel
                {
                    Fillings =  await Task.Run(() =>_fillingRepository.GetAll()),
                    Bisquits = await Task.Run(() => _bisquitRepository.GetAll()),
                    Creams = await Task.Run(() => _creamRepository.GetAll())
                };

                return View(partsModel);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"CakePart/Index:{ex.Message}");
                return View("Error");
            }
           
        }
    }
}