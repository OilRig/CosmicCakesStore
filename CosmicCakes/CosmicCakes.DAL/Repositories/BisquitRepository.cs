using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CosmicCakes.Logging.Interfaces;

namespace CosmicCakes.DAL.Repositories
{
    public class BisquitRepository : BaseRepository<Bisquit>, IBisquitRepository
    {
        public BisquitRepository(IAppLogger logger) : base(logger)
        {

        }
        public IEnumerable<Bisquit> GetAll()
        {
            using (var context = GetContext())
            {
                var query = (from b in context.Bisquits
                             select b)
                             .AsNoTracking()
                             .ToList();
                try
                {
                    if (!query.Any()) throw new Exception("Error getting all bisquits");
                    return query;
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
