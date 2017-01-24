using System.ComponentModel.DataAnnotations;

namespace CosmicCakes.DAL.Entities
{
    public class SimpleReadyCake
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double MinWeight { get; set; }
        public int KgPrice { get; set; }
        public bool IsLevelable { get; set; }
    }
}
