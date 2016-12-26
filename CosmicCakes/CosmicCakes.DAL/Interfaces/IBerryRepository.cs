using CosmicCakes.DAL.Entities;
using System.Collections.Generic;

namespace CosmicCakes.DAL.Interfaces
{
    public interface IBerryRepository : IRepository<Berry>
    {
        IEnumerable<string> GetAll();

    }
}
