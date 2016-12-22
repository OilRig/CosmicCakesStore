using CosmicCakes.Models;
using System.Web.Mvc;

namespace CosmicCakes.Controllers
{
    public class PriceController : Controller
    {
        // GET: Price
        public ActionResult Index()
        {
            var priceModel = new CreateCakeModel();
            return View(priceModel);
        }
    }
}