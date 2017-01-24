using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmicCakes.DAL.Repositories
{
    public class SimpleCakeRepository : ContextRepository<SimpleReadyCake>, ISimpleCakeRepository
    {
        public IEnumerable<SimpleReadyCake> GetAllCakes()
        {
            using (var context = GetCakeContext())
            {
                try
                {
                    var cakes = context.Set<SimpleReadyCake>()
                        .ToList();
                    return cakes;
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        public SimpleReadyCake GetCakeById(int id)
        {
            using (var context = GetCakeContext())
            {
                var cake = context.Set<SimpleReadyCake>().FirstOrDefault(c => c.Id == id);
                return cake;
            }
        }
    }
}
