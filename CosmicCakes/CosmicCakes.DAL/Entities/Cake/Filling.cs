using System.ComponentModel.DataAnnotations;
using CosmicCakes.DAL.Common;

namespace CosmicCakes.DAL.Entities
{

    public partial class Filling : IHasIntegerId
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
