using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CosmicCakes.DAL.Repositories
{
    public class SimpleCakeRepository : BaseRepository<SimpleReadyCake>, ISimpleCakeRepository
    {
        public SimpleCakeRepository(IAppLogger logger) : base(logger)
        {
            Logger = logger;
        }

        public IEnumerable<SimpleReadyCake> GetAllCakes()
        {
            using (var context = GetContext())
            {
                try
                {
                    var cakes = context.Set<SimpleReadyCake>()
                       .AsNoTracking()
                       .ToList();
               
                    if (cakes == null) throw new Exception("Error getting all cakes from DB");
                    return cakes;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);
                    throw;
                }

            }
        }

        public SimpleReadyCake GetCakeById(int id)
        {
            using (var context = GetContext())
            {
                try
                {
                    var cake = context.Set<SimpleReadyCake>().FirstOrDefault(c => c.Id == id);
                
                    if (cake == null)
                    {
                        throw new Exception("Error getting cake from DB. Cake Id is: " + id);
                    }
                    return cake;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);
                    throw;
                }

            }
        }

        public IEnumerable<SimpleReadyCake> GetExistingCakes()
        {
            using (var context = GetContext())
            {
                try
                {
                    var cakes = (from c in context.SimpleReadyCakes
                             where c.Id == 1 || c.Id == 2 || c.Id == 3 || c.Id == 5 || c.Id == 9 || c.Id == 10
                             select c)
                             .AsNoTracking()
                             .ToList();
               
                    if (!cakes.Any()) throw new Exception("Error getting cakes from DB");

                    return cakes;
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
