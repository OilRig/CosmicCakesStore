using CosmicCakes.DAL.Entities;
using System.Collections.Generic;

namespace CosmicCakes.DAL.Interfaces
{
    public interface ISimpleCakeRepository : IRepository<SimpleReadyCake>
    {
        IEnumerable<SimpleReadyCake> GetAllCakes();
    }
}
