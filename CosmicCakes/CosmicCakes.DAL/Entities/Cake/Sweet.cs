using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCakes.DAL.Entities.Cake
{
    public class Sweet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string MainInfo { get; set; }

        [Required]
        public int MinPcsCount { get; set; }

        [Required]
        public decimal PricePerPcs { get; set; }

        [Required]
        [StringLength(255)]
        public string BackgroundImagePath { get; set; }

        public bool IsActive { get; set; }
    }
}
