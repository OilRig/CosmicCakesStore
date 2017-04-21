using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CosmicCakes.DAL.Repositories
{
    public class FillingRepository : BaseRepository<Filling>, IFillingRepository
    {
        public FillingRepository(IAppLogger logger) : base(logger)
        {
            Logger = logger;
        }
        public IEnumerable<Filling> GetAll()
        {
            using (var context = GetContext())
            {
                var query = (from f in context.Fillings
                             select f)
                             .AsNoTracking()
                             .ToList();
                try
                {
                    if (query==null) throw new Exception("Error getting all fillings");
                    return query;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);
                    throw;
                }
            }
        }

        public IEnumerable<string> GetAllNamesOnly()
        {
            using (var context = GetContext())
            {
                var query = (from f in context.Fillings
                             select f.Type)
                             .AsNoTracking()
                             .ToList();
                try
                {
                    if (query==null) throw new Exception("Error getting all fillings");
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
