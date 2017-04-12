using CosmicCakes.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CosmicakesControlWebApp.Models
{
    public class PostModel
    {
        public string Author { get; set; }
        public string Theme { get; set; }
        public string Content { get; set; }
        public List<PostContentTemplate> PostTemplates { get; set; }
        public PostContentTemplate SelectedTemplate { get; set; }

    }
}
