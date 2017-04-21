using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmicCakes.Logging.Interfaces;

namespace CosmicCakes.DAL.Repositories
{
    public class UserSubscriptionRepository : BaseRepository<UserSubscribtion>, IUserSubscriptionRepository
    {
        public UserSubscriptionRepository(IAppLogger logger) : base(logger)
        {
            Logger = logger;
        }

        public IEnumerable<UserSubscribtion> GetAllSubscribedUsers()
        {
            using (var context = GetContext())
            {
                var query = context.UserSubscriptions
                    .AsNoTracking();
                try
                {

                    return query.ToList();
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
