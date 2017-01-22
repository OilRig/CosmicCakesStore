using CosmicCakes.DAL.Entities;
using System.Collections.Generic;

namespace CosmicCakes.DAL.Interfaces
{
    public interface IAdditionalDecorationRepository
    {
        IEnumerable<AdditionalDecoration> GetAll();
    }


}
