using CosmicCakes.DAL.Entities.Order;
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
        private readonly ICakeInventoryRepository _inventoryRepository;
        public OrderController(ICakeInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult> FastOrders()
        {
            var orders = await Task.Run(() => _inventoryRepository.GetAll<FastOrder>());

            var model = orders.Select(order => new Models.Orders.FastOrderModel()
            {
                Id = order.Id,
                Comments = order.Comments,
                CustomerName = order.CustomerName,
                CustomerPhoneNumber = order.CustomerPhoneNumber,
                ExpireDate = order.ExpireDate,
                SweetName = order.SweetName,
                WeightOrItemsCount = order.CakeStringWeightOrItemsCount
            });

            return View(model);

        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var orders = await Task.Run(() => _inventoryRepository.GetAll<Order>());

            var model = orders.Select(ord => new Models.Orders.Order
            {
                Id                        = ord.Id,
                CakeName                  = ord.CakeName,
                CakeWeight                = ord.CakeWeight,
                Comments                  = ord.Comments,
                CustomerName              = ord.CustomerName,
                CustomerPhoneNumber       = ord.CustomerPhoneNumber,
                DeliveryAdress            = ord.DeliveryAdress,
                DeliveryNeeded            = ord.DeliveryNeeded,
                ExpireDate                = ord.ExpireDate,
                OrderDate                 = ord.OrderDate,
                FillingType               = ord.FillingType,
                FirstLevelBisquit         = ord.FirstLevelBisquit,
                SecondLevelBisquit        = ord.SecondLevelBisquit,
                ThirdLevelBisquit         = ord.ThirdLevelBisquit,
                SelectedLevels            = ord.SelectedLevels,
                SelectedMultiLevelBisquit = ord.SelectedMultiLevelBisquit,
                SelectedOneLevelBisquit   = ord.SelectedOneLevelBisquit,
                CustonBisquits            = ord.SelectedLevels > 1 && (ord.FirstLevelBisquit != null && ord.SecondLevelBisquit != null && ord.ThirdLevelBisquit != null)
            });
            
            return View(model);
        }

        public async Task<ActionResult> AjaxDeleteOrder(int id)
        {
            var order = _inventoryRepository.GetById<Order>(id);

            await Task.Run(() => _inventoryRepository.Remove(order));

            return null;
        } 
    }
}