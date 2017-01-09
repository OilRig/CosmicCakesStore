using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakesWebApp.Models;
using System;
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
        public PriceController(ICreamRepository creamRepo, IBisquitRepository bisquitRepo,
           IFillingRepository fillingRepo, IBerryRepository berryRepo, IOrderRepository orderRepo)
        {
            _bisquitRepository = bisquitRepo;
            _berryRepository = berryRepo;
            _creamRepository = creamRepo;
            _fillingRepository = fillingRepo;
            _orderRepository = orderRepo;
        }
        public CreateCakePageModel CreatePageContent()
        {
            var cakePageModel = new CreateCakePageModel();
            var berries = _berryRepository.GetAll();
            var fillings = _fillingRepository.GetAll();
            var creams = _creamRepository.GetAll();
            var bisquits = _bisquitRepository.GetAll();
            foreach (var item in berries)
                cakePageModel.Berries.Add(item);
            foreach (var item in fillings)
                cakePageModel.Filling.Add(item);
            foreach (var item in creams)
                cakePageModel.Cream.Add(item);
            foreach (var item in bisquits)
                cakePageModel.Bisquit.Add(item);
            return cakePageModel;
        }

        private OrderModel MakeOrder(CreateCakePageModel model)
        {
            var orderModel = new OrderModel();
            orderModel.BisquitType = model.BisquitType;
            orderModel.CakeWeight = model.CakeWeight;
            orderModel.Comments = model.Comments;
            orderModel.FillingType = model.FillingType;
            orderModel.Berries = model.SelectedBerries;
            return orderModel;
        }
        private void SaveOrder(OrderModel model)
        {
            var order = new Order();
            order.Berries = model.Berries;
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

        // GET: Price
        public ActionResult Index()
        {
            return View(CreatePageContent()); //
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
            model.ExpireDate = model.ExpireDate.ToUniversalTime();
            SaveOrder(model);
            return RedirectToRoute("GoHome");

        }
    }
}