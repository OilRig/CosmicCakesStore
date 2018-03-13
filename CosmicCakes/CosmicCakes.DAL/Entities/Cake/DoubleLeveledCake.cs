using System.ComponentModel.DataAnnotations;
using CosmicCakes.DAL.Common;

namespace CosmicCakes.DAL.Entities
{
    public class DoubleLeveledCake : IHasIntegerId
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(3.5, 6)]
        public double MinWeight { get; set; }
        public int KgPrice { get; set; }
        public bool IsLevelable { get; set; }
    }
}
