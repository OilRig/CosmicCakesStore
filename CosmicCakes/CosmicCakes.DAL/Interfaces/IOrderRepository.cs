using CosmicCakes.DAL.Entities;
using System.Collections.Generic;

namespace CosmicCakes.DAL.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetAllOrders();
    }
}
