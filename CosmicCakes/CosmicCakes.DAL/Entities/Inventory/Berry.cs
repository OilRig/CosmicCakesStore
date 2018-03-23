using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmicCakes.DAL.Common;

namespace CosmicCakes.DAL.Entities.Inventory
{
    public class Berry : IHasIntegerId
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(60)]
        public string Name { get; set; }
    }
}
