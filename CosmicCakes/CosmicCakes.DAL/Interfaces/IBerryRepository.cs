using CosmicCakes.DAL.Entities;
using System.Collections;

namespace CosmicCakes.DAL.Interfaces
{
    public interface IBerryRepository : IRepository<Berry>
    {
        IEnumerable GetAll();

    }
}
