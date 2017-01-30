using CosmicCakes.DAL.Interfaces;
using CosmicCakes.DAL.Repositories;
using Ninject.Modules;



namespace CosmicCakes.Ninject
{
    public class NinjectConfigure : NinjectModule
    {
        public override void Load()
        {
            //Repositories
            Bind<IBerryRepository>().To<BerryRepository>();
            Bind<IBisquitRepository>().To<BisquitRepository>();
            Bind<ICreamRepository>().To<CreamRepository>();
            Bind<IFillingRepository>().To<FillingRepository>();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<ICreamDecorationsRepository>().To<CreamDecorationsRepository>();
            Bind<IAdditionalDecorationRepository>().To<AdditionalDecorationRepository>();
            Bind<ISimpleCakeRepository>().To<SimpleCakeRepository>();
            Bind<IImageRepository>().To<ImageRepository>();
            //Loggers
            //Bind<IAppLogger>().To<NlogLogger>();
        }
    }
}
