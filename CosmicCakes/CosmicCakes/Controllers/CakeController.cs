﻿using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CosmicCakes.Controllers
{
    public class CakeController : Controller
    {
        private readonly ISimpleCakeRepository _simpleCakeRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IPriceIncludementRepository _priceIncludementRepository;
        private readonly List<CakesStartPageModel> _existingCakes;
        public CakeController(ISimpleCakeRepository simpleCakeRepository, IImageRepository imageRepository,
            IPriceIncludementRepository priceIncludementRepository)
        {
            _simpleCakeRepository = simpleCakeRepository;
            _imageRepository = imageRepository;
            _priceIncludementRepository = priceIncludementRepository;
            _existingCakes = new List<CakesStartPageModel>();
        }
        // GET: Cake
        [HttpGet]
        public ActionResult Index()
        {
            var cakes = _simpleCakeRepository.GetExistingCakes();
            foreach (var cake in cakes)
            {
                _existingCakes.Add(new CakesStartPageModel
                {
                    Id = cake.Id,
                    Description = cake.Description,
                    Name = cake.Name,
                    KgPrice = cake.KgPrice,
                    MinWeight = cake.MinWeight,
                    MinPrice = cake.MinPrice,
                    BackgroundImagePath = cake.BackgroundImagePath,
                    ImagePaths = _imageRepository.GetAllImagePathsByCakeId(cake.Id)
                });
            }
            return View(_existingCakes);
        }

        [HttpGet]
        public ActionResult CakeInfo(int id)
        {
            var cake = _simpleCakeRepository.GetCakeById(id);
            var infoModel = new CakeInfoModel
            {
                Name = cake.Name,
                KgPrice = cake.KgPrice,
                MinWeight = cake.MinWeight,
                MinPrice = cake.MinPrice,
                Description = cake.Description,
                IsLevelable = cake.IsLevelable,
                MaxWeight = cake.MaxWeight,
                IndividualSquareImagesPaths = _imageRepository.GetCakeIndividualSquareImagesByCakeId(cake.Id),
                IndividualRectangleImagesPaths = _imageRepository.GetCakeIndividualRectangleImagesByCakeId(cake.Id),
                PriceIncludements = _priceIncludementRepository.GetAllPriceIncludementsById(id)
            };
            return View(infoModel);
        }
    }
}