using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using CosmicCakes.Logging.Interfaces;
using System.Linq;

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
                var cakes = context.Orders
                       .AsNoTracking()
                       .ToList();
                try
                {
                    if (cakes == null) throw new Exception("Error getting all orders from DB");
                    return cakes;
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
