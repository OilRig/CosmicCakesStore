namespace CosmicCakes.DAL
{
    using System.ComponentModel.DataAnnotations;

    public class CreamDecorarion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string DecoreType { get; set; }
    }
}
