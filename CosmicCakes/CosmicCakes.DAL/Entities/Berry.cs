using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCakes.DAL.Entities
{
    public class Berry
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(60)]
        public string Name { get; set; }
    }
}
