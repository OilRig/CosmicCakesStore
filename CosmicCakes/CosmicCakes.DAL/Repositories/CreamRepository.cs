using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CosmicCakes.Logging.Interfaces;

namespace CosmicCakes.DAL.Repositories
{
    public class CreamRepository : BaseRepository<Cream>, ICreamRepository
    {
        public CreamRepository(IAppLogger logger) : base(logger)
        {
            Logger = logger;
        }
        public IEnumerable<Cream> GetAll()
        {
            using (var context = GetContext())
            {

                var query = (from c in context.Cream
                             select c)
                             .AsNoTracking()
                             .ToList();
                try
                {
                    if (!query.Any()) throw new Exception("Error getting creams");
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
