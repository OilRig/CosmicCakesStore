using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CosmicCakes.DAL.Common;

namespace CosmicCakes.DAL.Entities
{
    public class CommonSweet : IHasIntegerId, IHasActiveMark
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(1000)]
        public string MainInfo { get; set; }

        public double MinWeight { get; set; }

        public int MinOrderItemsCount { get; set; }

        public decimal PricePerItem { get; set; }

        [Required]
        public int MaxWeight { get; set; }

        public decimal PricePerKilo { get; set; }

        public bool IsLevelable { get; set; }

        [Required]
        [StringLength(255)]
        public string BackgroundImagePath { get; set; }

        public bool IsActive { get; set; }

        public bool IsCake { get; set; }

        public bool IsAdditionalSweet { get; set; }
    }
}
