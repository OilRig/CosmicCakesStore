namespace CosmicCakes.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class AdditionalDecoration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
