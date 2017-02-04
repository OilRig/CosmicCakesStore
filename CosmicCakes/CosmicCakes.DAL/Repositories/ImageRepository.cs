using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CosmicCakes.DAL.Repositories
{
    public class ImageRepository : ContextRepository<SimpleCakeImage>, IImageRepository
    {
        public IEnumerable<string> GetAllImagePathsByCakeId(int cakeId)
        {
            using (var context = GetCakeContext())
            {
                var imagePaths = (from p in context.SimpleCakeImages
                                  where p.CakeId == cakeId
                                  select p.Path).AsNoTracking();
                return imagePaths.ToList();
            }
        }

        public IEnumerable<string> GetCakeIndividualSquareImagesByCakeId(int cakeId)
        {
            using (var context = GetCakeContext())
            {
                var imagePaths = (from p in context.CakeIndividualSquareImages
                                  where p.CakeId == cakeId
                                  select p.Path).AsNoTracking();
                return imagePaths.ToList();
            }
        }

        public IEnumerable<string> GetCakeIndividualRectangleImagesByCakeId(int cakeId)
        {
            using (var context = GetCakeContext())
            {
                var imagePaths = (from p in context.CakeIndividualRectangleImages
                                  where p.CakeId == cakeId
                                  select p.Path).AsNoTracking();
                return imagePaths.ToList();
            }
        }


    }
}
