using CosmicCakes.DAL.Entities;
using System.Collections.Generic;

namespace CosmicCakes.DAL.Interfaces
{
    public interface IBisquitRepository : IRepository<Bisquit>
    {
        IEnumerable<Bisquit> GetAll();
        IEnumerable<string> GetAllNamesOnly();
    }
}
