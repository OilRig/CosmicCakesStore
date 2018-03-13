using CosmicCakes.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCakes.DAL.Interfaces
{
    public interface IPostTemplateRepository 
    {
        IEnumerable<PostContentTemplate> GetAllTemplates();
        PostContentTemplate GetTemplateByName(string name);
        IEnumerable<string> GetAllTemplatesNamesOnly();
    }
}
