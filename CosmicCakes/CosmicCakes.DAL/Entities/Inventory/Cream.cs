using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CosmicCakes.DAL.Common;

namespace CosmicCakes.DAL.Entities.Inventory
{
    public class Cream : IHasIntegerId
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
