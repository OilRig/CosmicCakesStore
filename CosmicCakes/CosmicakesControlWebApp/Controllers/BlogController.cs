using CosmicakesControlWebApp.Models;
using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Interfaces;
using System;
using System.Web.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CosmicakesControlWebApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostTemplateRepository _postTemplateRepository;
        private readonly ICakeInventoryRepository _inventoryRepository;
        public BlogController(IPostTemplateRepository postTemplateRepository, ICakeInventoryRepository inventoryRepository)
        {
            _inventoryRepository    = inventoryRepository;
            _postTemplateRepository = postTemplateRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var templateNames = Task.Run(() => _postTemplateRepository.GetAllTemplatesNamesOnly().Where(t=>!t.EndsWith("EditArea")));

                var model = new BestPostModel
                {
                    PostTemplatesNames = await templateNames
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
        public async Task<ActionResult> SavePost(BestPostModel model)
        {
            if (ModelState.IsValid)
            {
                var post = new BlogPost()
                {
                    Author = model.Author,
                    Content = model.MainContent,
                    Theme = model.Theme,
                    CreationDate = DateTime.UtcNow
                };

                await Task.Run(() => _inventoryRepository.Add(post));

                return View();
            }
            return View("Error");
        }

        [HttpGet]
        public PartialViewResult LoadTemplate(string templateName)
        {
            object model = new object();
            switch(templateName)
            {
                case "BestPostTemplate":
                    {
                        model = new BestPostModel();
                        var name = templateName + "EditArea";
                        var template = _postTemplateRepository.GetTemplateByName(name);
                        return PartialView("BestPost.partial",model);
                    }
                default:return null;
            }
            
        }
    }
}