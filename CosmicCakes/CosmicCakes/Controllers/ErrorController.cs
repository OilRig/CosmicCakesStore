using System.Web.Mvc;

namespace CosmicCakes.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult PageNotFound()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Error500()
        {
            return View();
        }
        [HttpGet]
        public ActionResult General()
        {
            return View();
        }
    }
}