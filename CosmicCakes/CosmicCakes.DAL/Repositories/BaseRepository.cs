using CosmicCakes.DAL.Interfaces;
using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;

namespace CosmicCakes.DAL.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected DbContext GetContext(string connectionString = null)
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
                catch (Exception)
                {
                    throw;
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
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable GetAll()
        {
            using (var context = GetContext())
            {
                try
                {
                    var query = context.Set<T>().AsNoTracking().ToList();

                    return query.AsEnumerable();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
