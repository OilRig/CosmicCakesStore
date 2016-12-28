using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CosmicCakes.DAL.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public IEnumerable<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }
    }
}
