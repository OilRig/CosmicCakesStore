using CosmicakesControlWebApp.Models;
using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System;
using System.Web.Mvc;
using System.Linq;

namespace CosmicakesControlWebApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostTemplateRepository _postTemplateRepository;
        private readonly IBlogRepository _blogRepository;
        public BlogController(IBlogRepository blogRepository,IPostTemplateRepository postTemplateRepository)
        {
            _blogRepository = blogRepository;
            _postTemplateRepository = postTemplateRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var templateNames = _postTemplateRepository.GetAllTemplatesNamesOnly();

                var model = new PostModel
                {
                    PostTemplatesNames = templateNames
                };

                return View(model);
            }
            catch(Exception e)
            {
                return View("ErrorTemplate",e);
            }
            
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
                    Theme = model.Theme,
                    CreationDate = DateTime.UtcNow
                };
                _blogRepository.Add(post);
                return View();
            }
            return View("Error");
        }

        [HttpGet]
        public JsonResult LoadTemplate(string templateName)
        {
            var template = _postTemplateRepository.GetTemplateByName(templateName);
            return Json(template.Body, JsonRequestBehavior.AllowGet);
        }
    }
}