using CosmicCakes.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CosmicakesControlWebApp.Models
{
    public class BestPostModel
    {
        public string Author { get; set; }
        public string Theme { get; set; }
        public string Heading { get; set; }
        public string Opening { get; set; }
        public string FirstSubHeading { get; set; }
        public string BigPromise { get; set; }
        public string MainContent { get; set; }
        public string Quote { get; set; }
        public string OpenImageUrl { get; set; }
        public string CloseImageUrl { get; set; }
        public string HowToSection { get; set; }
        public IEnumerable<string> PostTemplatesNames { get; set; }
        public string SelectedTemplateName { get; set; }

    }
}
