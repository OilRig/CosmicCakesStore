using System;
using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CosmicCakes.Logging.Interfaces;

namespace CosmicCakes.DAL.Repositories
{
    public class PriceIncludementsRepository : BaseRepository<IndividualPriceIncludement>, IPriceIncludementRepository
    {
        public PriceIncludementsRepository(IAppLogger logger) : base(logger)
        {
            Logger = logger;
        }
        public IEnumerable<string> GetAllPriceIncludementsById(int cakeId)
        {
            using (var context = GetContext())
            {
                var includements =
                    context.IndividualCakePriceIncludements.Where(i => i.CakeId == cakeId)
                    .Select(i => i.IncludementInfo)
                    .AsNoTracking()
                    .ToList();
                try
                {
                    if (!includements.Any()) throw new Exception($"Error getting all price includements by cake id = {cakeId}");
                    return includements;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);
                    throw;
                }
            }
        }
    }
}
