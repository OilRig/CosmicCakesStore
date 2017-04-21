using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCakes.DAL.Entities
{
    public class EmailTemplate
    {
        public int Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        public string Body { get; set; }
        [MaxLength(16)]
        public string Encoding { get; set; }
    }
}
