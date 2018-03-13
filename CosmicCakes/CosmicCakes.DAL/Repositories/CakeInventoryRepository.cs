using CosmicCakes.DAL.Common;
using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CosmicCakes.DAL.Helpers;
using System.Threading;

namespace CosmicCakes.DAL.Repositories
{
    public class CakeInventoryRepository : ICakeInventoryRepository
    {
        protected IAppLogger Logger;

        private readonly ReaderWriterLockSlim _dbSyncronizer;

        private T[] ExecuteArrayFetchSecure<T>(Func<T[]> returnValue) where T: class
        {
            try
            {
                using (var reader = new ReadLock(_dbSyncronizer))
                {
                    return returnValue();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);

                throw;
            }
        }

        private T ExecuteSingleFetchSecure<T>(Func<T> returnValue) where T : class
        {
            try
            {
                using (var reader = new ReadLock(_dbSyncronizer))
                {
                    return returnValue();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);

                throw;
            }         
        }

        private void ExecuteSingleEditSecure(Action action)
        {
            try
            {
                using (var writeLock = new WriteLock(_dbSyncronizer))
                {
                    action();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);

                throw;
            }           
        }


        public CakeInventoryRepository(IAppLogger logger)
        {
            Logger = logger;

            _dbSyncronizer = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        }

        public void Add<T>(T entity) where T : class, IHasIntegerId
        {
            ExecuteSingleEditSecure(() =>
            {
                using (var context = new DBContextFactory().CreateContext())
                {
                    context.Set<T>().Add(entity);
                    context.SaveChanges();
                }
            });
        }

        public void Remove<T>(T entity) where T : class, IHasIntegerId
        {
            ExecuteSingleEditSecure(() =>
            {
                using (var context = new DBContextFactory().CreateContext())
                {
                    context.Entry(entity).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            });
        }

        public T[] GetAll<T>() where T : class, IHasIntegerId
        {
            return ExecuteArrayFetchSecure(() =>
            {
                using (var context = new DBContextFactory().CreateContext())
                {
                    return context.Set<T>().AsNoTracking().ToArray();
                }
            });
        }

        public TMap[] GetAllWithMapping<T, TMap>(Expression<Func<T, TMap>> mapper)
        where T : class, IHasIntegerId
        where TMap : class
        {
            return ExecuteArrayFetchSecure(() =>
            {
                using (var context = new DBContextFactory().CreateContext())
                {
                    return context.Set<T>().AsNoTracking().Select(mapper).ToArray();
                }
            });    
        }

        public T GetById<T>(int id) where T : class, IHasIntegerId
        {
            return ExecuteSingleFetchSecure(() =>
            {
                using (var context = new DBContextFactory().CreateContext())
                {
                    return context.Set<T>().AsNoTracking().FirstOrDefault(entity => entity.Id == id);
                }
            });
        }

        public TMap[] GetAllWithMappingByForeignKey<T, TMap>(int cakeId, Expression<Func<T, TMap>> mapper)
        where T : class, IHasCakeForeignKey
        where TMap : class
        {
            return ExecuteArrayFetchSecure(() =>
            {
                using (var context = new DBContextFactory().CreateContext())
                {
                    return context.Set<T>().AsNoTracking().Where(entity => entity.CakeId == cakeId).Select(mapper).ToArray();
                }
            });
        }

        public T[] GetActiveItems<T>() where T: class, IHasActiveMark
        {
            return ExecuteArrayFetchSecure(() =>
            {
                using (var context = new DBContextFactory().CreateContext())
                {
                    return context.Set<T>().AsNoTracking().Where(entity => entity.IsActive).ToArray();
                }
            });  
        }
    }
}
