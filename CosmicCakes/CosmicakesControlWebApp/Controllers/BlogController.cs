using CosmicakesControlWebApp.Models;
using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System.Web.Mvc;

namespace CosmicakesControlWebApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SavePost(PostModel model)
        {
            if (ModelState.IsValid)
            {
                var post = new BlogPost()
                {
                    Author = model.Author,
                    Content = model.Content,
                    Theme = model.Theme
                };
                _blogRepository.Add(post);
                return View();
            }
            return View("Error");
        }
    }
}