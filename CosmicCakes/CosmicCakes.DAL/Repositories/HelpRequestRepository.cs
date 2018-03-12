using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Logging.Interfaces;

namespace CosmicCakes.DAL.Repositories
{
    public class HelpRequestRepository : BaseRepository<HelpRequest>, IHelpRequestRepository
    {
        public HelpRequestRepository(IAppLogger logger) : base(logger)
        {
            Logger = logger;
        }
    }
}
