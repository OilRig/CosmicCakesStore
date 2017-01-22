using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmicCakes.DAL.Repositories
{
    public class AdditionalDecorationRepository : ContextRepository<AdditionalDecoration>, IAdditionalDecorationRepository
    {
        public IEnumerable<AdditionalDecoration> GetAll()
        {
            using (var context = GetCakeContext())
            {
                try
                {
                    var allAdditionalDecors = context.Set<AdditionalDecoration>().ToList();
                    return allAdditionalDecors;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
