using System.ComponentModel.DataAnnotations;
using CosmicCakes.DAL.Common;

namespace CosmicCakes.DAL.Entities.Inventory
{
    public class Bisquit : IHasIntegerId
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
