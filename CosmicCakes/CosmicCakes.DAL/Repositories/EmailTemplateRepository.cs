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
//    public class EmailTemplateRepository : CakeInventoryRepository<EmailTemplate>, IEmailTemplateRepository
//    {
//        public EmailTemplateRepository(IAppLogger logger):base(logger)
//        {
//            Logger = logger;
//        }
//        public EmailTemplate GetTemplateByName(string templateName)
//        {
//            using (var context = GetContext())
//            {
//                var template = context.EmailTemplates
//                    .Where(t => t.Name.Equals(templateName))
//                    .FirstOrDefault();
//                try
//                {
//                    if (template == null) throw new Exception($"Error getting template with name = {templateName}");
//                    return template;
//                }
//                catch (Exception ex)
//                {
//                    Logger.Error(ex, DateTime.UtcNow + ":" + ex.Message);
//                    throw;
//                }
//            }
//        }

//        public IEnumerable<string>  GetTemplateNamesOnly()
//        {
//            using (var context = GetContext())
//            {
//                var templateNames = (from t in context.EmailTemplates
//                                select t.Name)
//                                .AsNoTracking()
//                                .ToList();
//                try
//                {
//                    if (templateNames == null) throw new Exception("Error getting temlateNames");
//                    return templateNames;
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
