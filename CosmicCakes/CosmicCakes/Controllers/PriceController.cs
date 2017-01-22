using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakesWebApp.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;


namespace CosmicCakesWebApp.Controllers
{
    public class PriceController : Controller
    {
        private readonly IBisquitRepository _bisquitRepository;
        private readonly IFillingRepository _fillingRepository;
        private readonly IBerryRepository _berryRepository;
        private readonly ICreamRepository _creamRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICreamDecorationsRepository _creamDecorationRepository;
        private readonly IAdditionalDecorationRepository _additionalDecorationRepository;
        public PriceController(ICreamRepository creamRepo, IBisquitRepository bisquitRepo,
           IFillingRepository fillingRepo, IBerryRepository berryRepo, IOrderRepository orderRepo,
           ICreamDecorationsRepository creamDecorRepo, IAdditionalDecorationRepository additionalDecorationRepository)
        {
            _bisquitRepository = bisquitRepo;
            _berryRepository = berryRepo;
            _creamRepository = creamRepo;
            _fillingRepository = fillingRepo;
            _orderRepository = orderRepo;
            _creamDecorationRepository = creamDecorRepo;
            _additionalDecorationRepository = additionalDecorationRepository;
        }
        public CreateCakePageModel CreatePageContent()
        {
            var cakePageModel = new CreateCakePageModel();
            var berries = _berryRepository.GetAll();
            var fillings = _fillingRepository.GetAll();
            var creams = _creamRepository.GetAll();
            var bisquits = _bisquitRepository.GetAll();
            var creamDecors = _creamDecorationRepository.GetAll();
            var additionalDecors = _additionalDecorationRepository.GetAll();
            foreach (var item in berries)
                cakePageModel.Berries.Add(item);
            foreach (var item in fillings)
                cakePageModel.Filling.Add(item);
            foreach (var item in creams)
                cakePageModel.Cream.Add(item);
            foreach (var item in bisquits)
                cakePageModel.Bisquit.Add(item);
            foreach (var item in creamDecors)
                cakePageModel.CreamDecorations.Add(item);
            foreach (var item in additionalDecors)
                cakePageModel.AdditionalDecorations.Add(item.Name);
            return cakePageModel;
        }

        private OrderModel MakeOrder(CreateCakePageModel model)
        {
            var orderModel = new OrderModel
            {
                BisquitType = model.BisquitType,
                CakeWeight = model.CakeWeight,
                Comments = model.Comments,
                FillingType = model.FillingType,
                Berries = model.SelectedBerries
            };

            return orderModel;
        }
        private void SaveOrder(OrderModel model)
        {
            var order = new Order();
            foreach (var berry in model.Berries) order.Berries += berry + ",";
            order.BisquitType = model.BisquitType;
            order.CakeWeight = model.CakeWeight;
            order.Comments = model.Comments;
            order.CustomerName = model.CustomerName;
            order.CustomerPhoneNumber = model.CustomerPhoneNumber;
            order.ExpireDate = model.ExpireDate;
            order.FillingType = model.FillingType;
            order.OrderDate = DateTime.Now;
            _orderRepository.Add(order);
        }
        public void SendOrder(string order)
        {
            var from = new MailAddress("cosmicakesofficial@gmail.com", "Order");

            var to = new MailAddress("golubevanora1@gmail.com");

            var m = new MailMessage(from, to);

            m.Subject = "Заказ";

            m.Body = order;


            var smtp = new SmtpClient("smtp.gmail.com", 587);

            smtp.Credentials = new NetworkCredential("cosmicakesofficial@gmail.com", "gbczgjgf2345");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }

        // GET: Price
        public ActionResult Index()
        {
            return View(CreatePageContent());
        }

        [HttpPost]
        public ActionResult Order(CreateCakePageModel model)
        {
            if (ModelState.IsValid)
            {
                return View(MakeOrder(model));
            }
            else
            {
                return View("Index", CreatePageContent());
            }

        }

        [HttpPost]
        public ActionResult ConfirmOrder(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                model.ExpireDate = model.ExpireDate.ToUniversalTime();
                SaveOrder(model);
                SendOrder(model.ToString());
                return RedirectToRoute("GoHome");
            }
            else return View("Order", model);


        }
    }
}