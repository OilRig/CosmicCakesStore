using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                    .AsNoTracking();
                try
                {
                    if (!query.Any()) throw new Exception("Error getting all posts");
                    return Enumerable.Reverse(query.ToList()); 
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);
                    throw;
                }


            }
        }

        public BlogPost GetPostById(int id)
        {
            using(var context = GetContext())
            {
                var query = context.BlogPosts
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
