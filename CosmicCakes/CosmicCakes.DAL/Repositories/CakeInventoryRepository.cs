using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCakes.DAL.Repositories
{
    public class CakeInventoryRepository : BaseRepository<Berry>, ICakeInventoryRepository
    {
        public CakeInventoryRepository(IAppLogger logger):base(logger)
        {
            Logger = logger;
        }

        public IEnumerable<Berry> GetAll()
        {
            try
            {
                using (var context = GetContext())
                {
                    return context.Berries.AsNoTracking().ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
