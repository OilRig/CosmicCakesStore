using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmicakesControlWebApp.Models
{
    public class AnnounceModel
    {
        public string Content { get; set; }
        public IEnumerable<string> TemplateNames { get; set; }
        public string SelectedTemplateName { get; set; }
        public IEnumerable<HttpPostedFileBase> AttachedFiles { get; set; }
        public int SubscribedUsers { get; set; }
        public AnnounceModel()
        {
            TemplateNames = new List<string>();
        }
    }
}