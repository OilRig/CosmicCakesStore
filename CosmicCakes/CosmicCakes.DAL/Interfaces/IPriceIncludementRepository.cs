using CosmicCakes.DAL.Entities;
using System.Collections.Generic;

namespace CosmicCakes.DAL.Interfaces
{
    public interface IPriceIncludementRepository : IRepository<IndividualPriceIncludement>
    {
        IEnumerable<string> GetAllPriceIncludementsById(int cakeId);
    }
}
