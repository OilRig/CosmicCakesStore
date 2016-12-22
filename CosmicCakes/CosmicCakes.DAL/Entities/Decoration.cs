using System.ComponentModel.DataAnnotations;

namespace CosmicCakes.DAL.Entities
{
    public class Decoration
    {
        [Key]
        public int DecorationId { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
    }
}
