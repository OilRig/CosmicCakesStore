namespace CosmicCakes.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class AdditionalDecoration
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
