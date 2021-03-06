﻿using CosmicCakes.DAL.Interfaces;
using CosmicCakes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CosmicCakes.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = new BlogItemsModel();
            var posts = await Task.Run(() => _blogRepository.GetAllPosts());
            foreach (var post in posts)
                model.BlogPosts.Add(post);
            return View(model);
        }
    }
}