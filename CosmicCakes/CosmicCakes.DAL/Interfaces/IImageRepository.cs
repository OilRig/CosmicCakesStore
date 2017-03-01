using CosmicCakes.DAL.Entities;
using System.Collections.Generic;

namespace CosmicCakes.DAL.Interfaces
{
    public interface IImageRepository : IRepository<SimpleCakeImage>
    {
        IEnumerable<string> GetAllImagePathsByCakeId(int cakeId);
        IEnumerable<string> GetCakeIndividualRectangleImagesByCakeId(int cakeId);
    }
}
