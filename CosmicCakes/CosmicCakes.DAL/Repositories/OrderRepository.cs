using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using CosmicCakes.Logging.Interfaces;
using System.Linq;
using System.Data.Entity;

namespace CosmicCakes.DAL.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(IAppLogger logger) : base(logger)
        {
            Logger = logger;
        }
        public IEnumerable<Order> GetAllOrders()
        {
            using (var context = GetContext())
            {
                var orders = context.Orders
                       .AsNoTracking()
                       .ToList();
                try
                {
                    if (orders == null) throw new Exception("Error getting all orders from DB");
                    return orders;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);
                    throw;
                }

            }
        }

        public Order GetOrderById(int id)
        {
            using (var context = GetContext())
            {
                var order = context.Orders
                       .Where(ord => ord.Id == id);      
                try
                {
                    if (order == null) throw new Exception("Error getting all orders from DB");
                    return order.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);
                    throw;
                }

            }
        }
    }
}
