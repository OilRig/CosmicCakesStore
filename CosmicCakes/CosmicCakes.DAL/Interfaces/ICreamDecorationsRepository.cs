using System.Collections.Generic;

namespace CosmicCakes.DAL.Interfaces
{
    public interface ICreamDecorationsRepository : IRepository<CreamDecorarion>
    {
        IEnumerable<string> GetAll();
    }
}