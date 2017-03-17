using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CosmicCakes.Controllers
{
    public class FeedbackController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}