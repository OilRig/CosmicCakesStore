using CosmicCakes.Logging.Interfaces;

namespace CosmicCakes.DAL.Repositories
{
    public class ContextRepository<T> : BaseRepository<T> where T : class
    {
        public ContextRepository(IAppLogger logger) : base(logger)
        {

        }
        //public CakeContext GetCakeContext()
        //{
        //    var context = GetContext();
        //    return context as CakeContext;
        //}
    }
}
