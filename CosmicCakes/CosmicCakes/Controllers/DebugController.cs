using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CosmicCakes.Models;

namespace CosmicCakes.Controllers
{
    public class DebugController : Controller
    {
        // GET: Debug
        public ActionResult Index()
        {
            return View(new OrderModel());
        }
    }
}