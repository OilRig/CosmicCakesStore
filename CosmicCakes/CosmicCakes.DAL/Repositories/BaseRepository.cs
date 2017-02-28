using CosmicCakes.DAL.Interfaces;
using System;
using System.Data.Entity;
using CosmicCakes.Logging.Interfaces;

namespace CosmicCakes.DAL.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly IAppLogger Logger;
        public BaseRepository(IAppLogger logger)
        {
            Logger = logger;
        }
        protected CakeContext GetContext(string connectionString = null)
        {
            return new CakeContext();
        }

        public void Add(T entity)
        {
            using (var context = GetContext())
            {
                try
                {
                    context.Set<T>().Add(entity);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);
                }

            }
        }
        public void Remove(T entity)
        {
            using (var context = GetContext())
            {
                try
                {
                    context.Set<T>().Remove(entity);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);
                }
            }
        }
    }
}
