using CosmicCakes.DAL.Entities;
using System.Collections.Generic;

namespace CosmicCakes.DAL.Interfaces
{
    public interface ICreamRepository : IRepository<Cream>
    {
        IEnumerable<Cream> GetAll();
    }
}
