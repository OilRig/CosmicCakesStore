using CosmicCakes.BL.HTMLContentLogic.Implementators;
using CosmicCakes.BL.HTMLContentLogic.Interfaces;
using Ninject.Modules;

namespace CosmicCakes.BL.DIBindings
{
    public class BLDIConfigure : NinjectModule
    {
        public override void Load()
        {
            Bind<IContentCreator>().To<DataBaseContentCreator>();
        }
    }
}
