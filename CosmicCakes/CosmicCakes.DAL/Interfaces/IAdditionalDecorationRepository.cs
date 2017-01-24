using CosmicCakes.DAL.Entities;
using System.Collections.Generic;

namespace CosmicCakes.DAL.Interfaces
{
    public interface IAdditionalDecorationRepository : IRepository<AdditionalDecoration>
    {
        IEnumerable<AdditionalDecoration> GetAll();
    }


}
