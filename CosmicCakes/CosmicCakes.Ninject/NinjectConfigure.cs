using CosmicCakes.DAL.Interfaces;
using CosmicCakes.DAL.Repositories;
using CosmicCakes.Logging.Interfaces;
using CosmicCakes.Logging.Loggers;
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
            //Loggers
            Bind<IAppLogger>().To<NLogLogger>();
        }
    }
}
