using CosmicCakes.DAL.Entities;
using System.Collections.Generic;

namespace CosmicCakes.DAL.Interfaces
{
    public interface IFillingRepository : IRepository<Filling>
    {
        IEnumerable<Filling> GetAll();
        IEnumerable<string> GetAllNamesOnly();
    }
}
