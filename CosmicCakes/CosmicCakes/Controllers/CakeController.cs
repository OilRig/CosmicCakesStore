using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CosmicCakes.Controllers
{
    public class CakeController : Controller
    {
        private readonly ISimpleCakeRepository _simpleCakeRepository;
        private readonly List<CakesStartPageModel> _existingCakes;
        public CakeController(ISimpleCakeRepository simpleCakeRepository)
        {
            _simpleCakeRepository = simpleCakeRepository;
            _existingCakes = new List<CakesStartPageModel>();
        }
        // GET: Cake
        public ActionResult Index()
        {
            var cakes = _simpleCakeRepository.GetAllCakes();
            foreach (var cake in cakes)
            {
                _existingCakes.Add(new CakesStartPageModel
                {
                    Id = cake.Id,
                    Description = cake.Description,
                    Name = cake.Name,
                    KgPrice = cake.KgPrice,
                    MinWeight = cake.MinWeight,
                    MinPrice = cake.MinPrice
                });
            }
            return View(_existingCakes);
        }

        public ActionResult CakeInfo(int id)
        {
            var cake = _simpleCakeRepository.GetCakeById(id);
            return View(cake);
        }
    }
}