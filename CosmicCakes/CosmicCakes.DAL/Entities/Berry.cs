using System.ComponentModel.DataAnnotations;

namespace CosmicCakes.DAL.Entities
{
    public class Berry
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
