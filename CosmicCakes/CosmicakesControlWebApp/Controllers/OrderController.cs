using CosmicCakes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CosmicakesControlWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEnumerable<Models.Orders.Order> _orders;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _orders = new List<Models.Orders.Order>();
        }
        // GET: Order
        public async Task<ActionResult> Index()
        {
            var orders = await Task.Run(() => _orderRepository.GetAllOrders());

            var model = orders.Select(ord => new Models.Orders.Order
            {
                Id = ord.Id,
                CakeName = ord.CakeName,
                CakeWeight = ord.CakeWeight,
                Comments = ord.Comments,
                CustomerName = ord.CustomerName,
                CustomerPhoneNumber = ord.CustomerPhoneNumber,
                DeliveryAdress = ord.DeliveryAdress,
                DeliveryNeeded = ord.DeliveryNeeded,
                ExpireDate = ord.ExpireDate,
                OrderDate = ord.OrderDate,
                FillingType = ord.FillingType,
                FirstLevelBisquit = ord.FirstLevelBisquit,
                SecondLevelBisquit = ord.SecondLevelBisquit,
                ThirdLevelBisquit = ord.ThirdLevelBisquit,
                SelectedLevels = ord.SelectedLevels,
                SelectedMultiLevelBisquit = ord.SelectedMultiLevelBisquit,
                SelectedOneLevelBisquit = ord.SelectedOneLevelBisquit,
                CustonBisquits = ord.SelectedLevels > 1 && (ord.FirstLevelBisquit != null && ord.SecondLevelBisquit != null && ord.ThirdLevelBisquit != null)
            });
            
            return View(model);
        }

        public async Task<ActionResult> AjaxDeleteOrder(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            await Task.Run(() => _orderRepository.Remove(order));

            return null;
        } 
    }
}