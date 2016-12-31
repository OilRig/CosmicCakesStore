using CosmicCakes.BL.HTMLContentLogic.Interfaces;
using CosmicCakes.DAL.Interfaces;
using CosmicCakesWebApp.Models;

namespace CosmicCakes.BL.HTMLContentLogic.Implementators
{
    public class DataBaseContentCreator : IContentCreator
    {
        private readonly IBisquitRepository _bisquitRepository;
        private readonly IFillingRepository _fillingRepository;
        private readonly IBerryRepository _berryRepository;
        private readonly ICreamRepository _creamRepository;
        private readonly IOrderRepository _orderRepository;
        public DataBaseContentCreator(ICreamRepository creamRepo, IBisquitRepository bisquitRepo,
           IFillingRepository fillingRepo, IBerryRepository berryRepo, IOrderRepository orderRepo)
        {
            _bisquitRepository = bisquitRepo;
            _berryRepository = berryRepo;
            _creamRepository = creamRepo;
            _fillingRepository = fillingRepo;
            _orderRepository = orderRepo;
        }
        public CreateCakePageModel CreateContent()
        {
            var cakePageModel = new CreateCakePageModel();
            var berries = _berryRepository.GetAll();
            var fillings = _fillingRepository.GetAll();
            var creams = _creamRepository.GetAll();
            var bisquits = _bisquitRepository.GetAll();
            foreach (var item in berries)
                cakePageModel.Berries.Add(item);
            foreach (var item in fillings)
                cakePageModel.Filling.Add(item);
            foreach (var item in creams)
                cakePageModel.Cream.Add(item);
            foreach (var item in bisquits)
                cakePageModel.Bisquit.Add(item);
            return cakePageModel;
        }
    }
}
