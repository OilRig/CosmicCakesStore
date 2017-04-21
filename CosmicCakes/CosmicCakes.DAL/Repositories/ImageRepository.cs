using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CosmicCakes.DAL.Repositories
{
    public class ImageRepository : BaseRepository<SimpleCakeImage>, IImageRepository
    {
        public ImageRepository(IAppLogger logger) : base(logger)
        {
            Logger = logger;
        }
        public IEnumerable<string> GetAllImagePathsByCakeId(int cakeId)
        {
            using (var context = GetContext())
            {
                var imagePaths = (from p in context.SimpleCakeImages
                                  where p.CakeId == cakeId
                                  select p.Path)
                                  .AsNoTracking()
                                  .ToList();
                try
                {
                    if (imagePaths==null) throw new Exception($"Error getting paths.Cake Id is:{cakeId}");
                    return imagePaths;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);
                    throw;
                }

            }
        }
        public IEnumerable<string> GetCakeIndividualRectangleImagesByCakeId(int cakeId)
        {
            using (var context = GetContext())
            {
                var imagePaths = (from p in context.CakeIndividualRectangleImages
                                  where p.CakeId == cakeId
                                  select p.Path)
                                  .AsNoTracking()
                                  .ToList();
                try
                {
                    if (imagePaths==null) throw new Exception($"Error getting rectangle paths. Cake Id is: {cakeId}");
                    return imagePaths;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);
                    throw;
                }
            }
        }
    }
}
