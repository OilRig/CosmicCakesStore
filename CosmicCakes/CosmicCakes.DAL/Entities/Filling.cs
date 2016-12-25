using System.ComponentModel.DataAnnotations;

namespace CosmicCakes.DAL.Entities
{

    public partial class Filling
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Type { get; set; }
    }
}
