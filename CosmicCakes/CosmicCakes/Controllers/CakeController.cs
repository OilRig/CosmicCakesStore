using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CosmicCakes.Controllers
{
    public class CakeController : Controller
    {
        private readonly ISimpleCakeRepository _simpleCakeRepository;
        private readonly IImageRepository _imageRepository;
        private readonly List<CakesStartPageModel> _existingCakes;
        public CakeController(ISimpleCakeRepository simpleCakeRepository, IImageRepository imageRepository)
        {
            _simpleCakeRepository = simpleCakeRepository;
            _imageRepository = imageRepository;
            _existingCakes = new List<CakesStartPageModel>();
        }
        // GET: Cake
        public ActionResult Index()
        {
            var cakes = _simpleCakeRepository.GetAllCakes().First(c => c.Id == 1);
            _existingCakes.Add(new CakesStartPageModel
            {
                Id = cakes.Id,
                Description = cakes.Description,
                Name = cakes.Name,
                KgPrice = cakes.KgPrice,
                MinWeight = cakes.MinWeight,
                MinPrice = cakes.MinPrice,
                ImagePaths = _imageRepository.GetAllImagePathsByCakeId(cakes.Id)
            });
            //foreach (var cake in cakes)
            //{
            //    _existingCakes.Add(new CakesStartPageModel
            //    {
            //        Id = cake.Id,
            //        Description = cake.Description,
            //        Name = cake.Name,
            //        KgPrice = cake.KgPrice,
            //        MinWeight = cake.MinWeight,
            //        MinPrice = cake.MinPrice,
            //        ImagePaths = _imageRepository.GetAllImagePathsByCakeId(cake.Id)
            //    });
            //}
            return View(_existingCakes);
        }

        [HttpGet]
        public ActionResult CakeInfo(int id)
        {
            var cake = _simpleCakeRepository.GetCakeById(id);
            return View(cake);
        }
    }
}