using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Logging.Interfaces;
using CosmicCakes.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CosmicCakes.Controllers
{
    public class HomeController : AppServiceController
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IFillingRepository _fillingRepository;
        private readonly IBisquitRepository _bisquitRepository;
        private readonly ICreamRepository _creamRepository;

        public HomeController(IBlogRepository blogRepository,IFillingRepository fillingRepository, IBisquitRepository bisquitRepository, ICreamRepository creamRepository,
            IAppLogger logger) : base(logger)
        {
            _blogRepository = blogRepository;
            _fillingRepository = fillingRepository;
            _bisquitRepository = bisquitRepository;
            _creamRepository = creamRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Prices()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Blog()
        {
            var model = new BlogItemsModel();
            var posts = await Task.Run(() => _blogRepository.GetAllPosts());
            foreach (var post in posts)
                model.BlogPosts.Add(post);
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> CakeParts()
        {
            try
            {
                var partsModel = new CakePartsModel
                {
                    Fillings = await Task.Run(() => _fillingRepository.GetAll()),
                    Bisquits = await Task.Run(() => _bisquitRepository.GetAll()),
                    Creams   = await Task.Run(() => _creamRepository.GetAll())
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