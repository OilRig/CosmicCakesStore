using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CosmicCakes.DAL.Entities
{
    [Table("Cream")]
    public class Cream
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Type { get; set; }
    }
}
