﻿using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmicCakes.DAL.Repositories
{
    public class CreamRepository : ContextRepository<Cream>, ICreamRepository
    {
        public IEnumerable<string> GetAll()
        {
            using (var context = GetCakeContext())
            {
                try
                {
                    var query = from c in context.Cream
                                select c.Type;
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
