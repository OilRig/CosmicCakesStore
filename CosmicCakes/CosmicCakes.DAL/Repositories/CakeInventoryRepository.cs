using CosmicCakes.DAL.Common;
using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CosmicCakes.DAL.Repositories
{
    public class CakeInventoryRepository : ICakeInventoryRepository
    {
        protected IAppLogger Logger;

        public CakeInventoryRepository(IAppLogger logger)
        {
            Logger = logger;
        }

        public void Add<T>(T entity) where T : class, IHasIntegerId
        {
            using (var context = new DBContextFactory().CreateContext())
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

        public void Remove<T>(T entity) where T : class, IHasIntegerId
        {
            using (var context = new DBContextFactory().CreateContext())
            {
                try
                {
                    context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);
                }
            }
        }

        public T[] GetAll<T>() where T : class, IHasIntegerId
        {
            using (var context = new DBContextFactory().CreateContext())
            {
                return context.Set<T>().AsNoTracking().ToArray();
            }
        }

        public TMap[] GetAllWithMapping<T,TMap>(Expression<Func<T, TMap>> mapper)
        where T : class, IHasIntegerId
        where TMap : class
        {
            using (var context = new DBContextFactory().CreateContext())
            {
                return context.Set<T>().AsNoTracking().Select(mapper).ToArray();
            }
        }

        public T GetById<T>(int id) where T : class, IHasIntegerId
        {
            using (var context = new DBContextFactory().CreateContext())
            {
                return context.Set<T>().AsNoTracking().FirstOrDefault(entity => entity.Id == id);
            }
        }

        public TMap[] GetAllWithMappingByForeignKey<T, TMap>(int cakeId, Expression<Func<T, TMap>> mapper)
        where T : class, IHasCakeForeignKey
        where TMap : class
        {
            using (var context = new DBContextFactory().CreateContext())
            {
                return context.Set<T>().AsNoTracking().Where(entity => entity.CakeId == cakeId).Select(mapper).ToArray();
            }
        }

        public T[] GetActiveItems<T>() where T: class, IHasActiveMark
        {
            using (var context = new DBContextFactory().CreateContext())
            {
                return context.Set<T>().AsNoTracking().Where(entity => entity.IsActive).ToArray();
            }
        }
    }
}
