using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CosmicCakes.DAL.Common;

namespace CosmicCakes.DAL.Entities
{
    public class SimpleReadyCake : IHasIntegerId, IHasActiveMark
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
        public double MinWeight { get; set; }
        [Required]
        public int MinPrice { get; set; }
        [Required]
        public int MaxWeight { get; set; }
        public int KgPrice { get; set; }
        public bool IsLevelable { get; set; }
        [Required]
        [StringLength(255)]
        public string BackgroundImagePath { get; set; }

        public bool IsActive { get; set; }
    }
}
