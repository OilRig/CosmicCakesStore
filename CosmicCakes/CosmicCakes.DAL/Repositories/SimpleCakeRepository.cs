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

        public IEnumerable<SimpleReadyCake> GetExistingCakes()
        {
            using (var context = GetCakeContext())
            {
                var cakes = from c in context.SimpleReadyCakes
                            where c.Id == 1 || c.Id == 3 || c.Id == 3 || c.Id == 5 || c.Id == 9
                            select c;
                return cakes;
            }
        }
    }
}
