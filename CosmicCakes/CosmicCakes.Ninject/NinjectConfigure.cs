using CosmicCakes.DAL.Common;
using CosmicCakes.DAL.Interfaces;
using CosmicCakes.DAL.Repositories;
using CosmicCakes.Logging.Interfaces;
using CosmicCakes.Logging.Loggers;
using CosmicCakes.Services.EmailService;
using Ninject.Modules;



namespace CosmicCakes.Ninject
{
    public class NinjectConfigure : NinjectModule
    {
        public override void Load()
        {
            //Repositories
            //Bind<ISimpleCakeRepository>().To<SimpleCakeRepository>();
            //Bind<IImageRepository>().To<ImageRepository>();
            //Bind<IPostTemplateRepository>().To<PostTemplateRepository>();
            //Bind<IEmailTemplateRepository>().To<EmailTemplateRepository>();
            //Bind<IHelpRequestRepository>().To<HelpRequestRepository>();
            Bind<ICakeInventoryRepository>().To<CakeInventoryRepository>();
            //Loggers
            Bind<IAppLogger>().To<NLogLogger>();
            //Services
            Bind<IEmailSender>().To<EmailSender>();
        }
    }
}
