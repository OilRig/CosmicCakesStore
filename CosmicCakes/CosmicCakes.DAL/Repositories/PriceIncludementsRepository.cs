using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CosmicCakes.DAL.Repositories
{
    public class PriceIncludementsRepository : ContextRepository<IndividualPriceIncludement>, IPriceIncludementRepository
    {
        public IEnumerable<string> GetAllPriceIncludementsById(int cakeId)
        {
            using (var context = GetCakeContext())
            {
                var includements =
                    context.IndividualCakePriceIncludements.Where(i => i.CakeId == cakeId).Select(i => i.IncludementInfo)
                    .AsNoTracking()
                    .ToList();
                return includements;
            }
        }
    }
}
