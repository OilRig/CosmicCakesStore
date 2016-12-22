using System.ComponentModel.DataAnnotations;

namespace CosmicCakes.DAL.Entities
{
    public class Bisquit
    {
        [Key]
        public int BisquitId { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
    }
}
