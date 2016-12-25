using System.Collections;

namespace CosmicCakes.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Remove(T entity);
        IEnumerable GetAll();
    }
}
