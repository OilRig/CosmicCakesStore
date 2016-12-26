using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmicCakes.DAL.Repositories
{
    public class BerryRepository : ContextRepository<Berry>, IBerryRepository
    {
        public IEnumerable<string> GetAll()
        {
            using (var context = GetCakeContext())
            {
                try
                {
                    var query = from b in context.Berries
                                select b.Name;


                    return query.ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
