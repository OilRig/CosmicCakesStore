using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CosmicCakes.DAL.Common;
using CosmicCakes.DAL.Entities;

namespace CosmicCakes.DAL.Interfaces
{
    public interface ICakeInventoryRepository  
    {
        void Add<T>(T entity) where T : class, IHasIntegerId;

        void Remove<T>(T entity) where T : class, IHasIntegerId;

        T[] GetAll<T>() where T : class, IHasIntegerId;

        TMap[] GetAllWithMapping<T, TMap>(Expression<Func<T, TMap>> mapper)
        where T : class, IHasIntegerId
        where TMap : class;

        TMap[] GetAllWithMappingByForeignKey<T, TMap>(int cakeId, Expression<Func<T, TMap>> mapper)
        where T : class, IHasSweetForeignKey
        where TMap : class;

        T GetById<T>(int id) where T : class, IHasIntegerId;

        T[] GetActiveItems<T>() where T : class, IHasActiveMark;
    }
}
