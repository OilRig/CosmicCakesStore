using CosmicCakes.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCakes.DAL.Entities.Sweets
{
    public class AdditionalSweet : IHasIntegerId
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public decimal  StartPricePerPcs { get; set; }
    }
}
