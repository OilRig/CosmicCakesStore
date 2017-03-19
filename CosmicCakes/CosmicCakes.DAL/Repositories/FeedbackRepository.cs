using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCakes.DAL.Repositories
{
    public class FeedbackRepository:BaseRepository<UserFeedback>,IFeedbackRepository
    {
        public FeedbackRepository(IAppLogger logger) : base(logger)
        {
            Logger = logger;
        }
        public IEnumerable<UserFeedback> GetAllFeedbacks()
        {
            using (var context = GetContext())
            {
                var query = context.UserFeedbacks
                    .AsNoTracking()
                    .ToList();
                try
                {
                    return query;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);
                    throw;
                }


            }
        }

        public UserFeedback GetFeedbackById(int id)
        {
            using (var context = GetContext())
            {
                var query = context.UserFeedbacks
                    .Where(b => b.Id == id)
                    .AsNoTracking()
                    .FirstOrDefault();
                try
                {
                    if (query == null) throw new Exception($"Error getting post with id = {id}");
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
