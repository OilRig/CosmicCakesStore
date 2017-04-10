using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Models;
using System;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;


namespace CosmicCakes.Controllers
{
    public class PriceController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();

        }
    }
}