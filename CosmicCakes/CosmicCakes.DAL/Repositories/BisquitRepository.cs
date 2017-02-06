using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmicCakes.DAL.Repositories
{
    public class BisquitRepository : ContextRepository<Bisquit>, IBisquitRepository
    {
        public IEnumerable<Bisquit> GetAll()
        {
            using (var context = GetCakeContext())
            {
                try
                {
                    var query = from b in context.Bisquits
                                select b;
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
