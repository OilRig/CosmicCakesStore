﻿using CosmicCakes.DAL.Interfaces;
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
            Bind<IBisquitRepository>().To<BisquitRepository>();
            Bind<ICreamRepository>().To<CreamRepository>();
            Bind<IFillingRepository>().To<FillingRepository>();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<ISimpleCakeRepository>().To<SimpleCakeRepository>();
            Bind<IImageRepository>().To<ImageRepository>();
            Bind<IPriceIncludementRepository>().To<PriceIncludementsRepository>();
            Bind<IBlogRepository>().To<BlogRepository>();
            Bind<IFeedbackRepository>().To<FeedbackRepository>();
            Bind<IPostTemplateRepository>().To<PostTemplateRepository>();
            Bind<IUserSubscriptionRepository>().To<UserSubscriptionRepository>();
            Bind<IEmailTemplateRepository>().To<EmailTemplateRepository>();
            //Loggers
            Bind<IAppLogger>().To<NLogLogger>();
            //Services
            Bind<IEmailSender>().To<EmailSender>();
        }
    }
}
