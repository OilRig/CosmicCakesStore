using CosmicCakes.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmicCakes.DAL.Interfaces
{
    public interface ISimpleCakeRepository : IRepository<SimpleReadyCake>
    {
        IEnumerable<SimpleReadyCake> GetAllCakes();
        SimpleReadyCake GetCakeById(int id);
        IEnumerable<SimpleReadyCake> GetExistingCakes();
    }
}
