using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmicCakes.DAL.Repositories
{
    public class FillingRepository : ContextRepository<Filling>, IFillingRepository
    {
        public IEnumerable<string> GetAll()
        {
            using (var context = GetCakeContext())
            {
                try
                {
                    var query = from f in context.Fillings
                                select f.Type;
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
