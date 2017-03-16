using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmicCakes.DAL.Repositories
{
    public class BlogRepository : BaseRepository<BlogPost>, IBlogRepository
    {
        public BlogRepository(IAppLogger logger) : base(logger)
        {
            Logger = logger;
        }
        public IEnumerable<BlogPost> GetAllPosts()
        {
            using (var context = GetContext())
            {
                var query = context.BlogPosts
                    .AsNoTracking()
                    .ToList();
                try
                {
                    if (!query.Any()) throw new Exception("Error getting all posts");
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
