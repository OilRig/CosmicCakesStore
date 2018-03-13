//using CosmicCakes.DAL.Entities;
//using CosmicCakes.DAL.Interfaces;
//using CosmicCakes.Logging.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CosmicCakes.DAL.Repositories
//{
//    public class PostTemplateRepository :  IPostTemplateRepository
//    {
//        public PostTemplateRepository(IAppLogger logger) : base(logger)
//        {
//            Logger = logger;
//        }
//        public IEnumerable<PostContentTemplate> GetAllTemplates()
//        {
//            using (var context = GetContext())
//            {
//                var query = (from b in context.PostTemplates
//                             select b)
//                             .AsNoTracking()
//                             .ToList();
//                try
//                {
//                    if (query==null) throw new Exception("Error getting all templates");
//                    return query;
//                }
//                catch (Exception ex)
//                {
//                    Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);
//                    throw;
//                }

//            }
//        }

//        public IEnumerable<string> GetAllTemplatesNamesOnly()
//        {
//            using (var context = GetContext())
//            {
//                var query = (from b in context.PostTemplates
//                             select b.Name)
//                             .AsNoTracking()
//                             .ToList();
//                try
//                {
//                    if (query==null) throw new Exception("Error getting all templates");
//                    return query;
//                }
//                catch (Exception ex)
//                {
//                    Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);
//                    throw;
//                }

//            }
//        }

//        public PostContentTemplate GetTemplateByName(string name)
//        {
//            using (var context = GetContext())
//            {
//                var query = context.PostTemplates
//                    .Where(b => b.Name == name)
//                    .AsNoTracking()
//                    .FirstOrDefault();
//                try
//                {
//                    if (query == null) throw new Exception($"Error getting template with id = {name}");
//                    return query;
//                }
//                catch (Exception ex)
//                {
//                    Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);
//                    throw;
//                }


//            }
//        }
//    }
//}
