using System.ComponentModel.DataAnnotations;

namespace CosmicCakes.DAL.Entities
{
    public class Filling
    {
        [Key]
        public int FillingId { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
    }
}
