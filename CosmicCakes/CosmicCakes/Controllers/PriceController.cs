using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;


namespace CosmicCakesWebApp.Controllers
{
    public class PriceController : Controller
    {

        private readonly IOrderRepository _orderRepository;
        private readonly ISimpleCakeRepository _cakeRepository;

        public PriceController(IOrderRepository orderRepo, ISimpleCakeRepository cakeRepository)
        {
            _orderRepository = orderRepo;
            _cakeRepository = cakeRepository;
        }
        private void SaveOrder(OrderModel model)
        {
            var order = new Order();
            order.CakeWeight = model.CakeWeight;
            order.Comments = model.Comments;
            order.CustomerName = model.CustomerName;
            order.CustomerPhoneNumber = model.CustomerPhoneNumber;
            order.ExpireDate = model.ExpireDate;
            order.OrderDate = DateTime.Now;
            order.CakeName = model.CakeName;
            _orderRepository.Add(order);
        }
        private void SendOrder(string order)
        {
            var from = new MailAddress("cosmicakesofficial@gmail.com", "Order");

            var to = new MailAddress("golubevanora1@gmail.com");

            using (var m = new MailMessage(from, to))
            {
                m.Subject = "Заказ";
                m.Body = order;

                var smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("cosmicakesofficial@gmail.com", "gbczgjgf2345");
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
        }

        [HttpPost]
        public ActionResult MakeOrder(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                model.ExpireDate = model.ExpireDate.ToUniversalTime();
                model.CakeName = _cakeRepository.GetCakeById(model.Id).Name;
                SaveOrder(model);
                //SendOrder(model.ToString());
                return View();
            }
            return RedirectToAction("Cake/CakeInfo", model);

        }
    }
}