﻿using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CosmicCakes.Logging.Interfaces;

namespace CosmicCakes.DAL.Repositories
{
    public class FillingRepository : BaseRepository<Filling>, IFillingRepository
    {
        public FillingRepository(IAppLogger logger) : base(logger)
        {
            Logger = logger;
        }
        public IEnumerable<Filling> GetAll()
        {
            using (var context = GetContext())
            {
                var query = (from f in context.Fillings
                             select f)
                             .AsNoTracking()
                             .ToList();
                try
                {
                    if (!query.Any()) throw new Exception("Error getting all fillings");
                    return query;
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
