using System.ComponentModel.DataAnnotations;

namespace CosmicCakes.DAL.Entities
{
    public class Berry
    {
        [Key]
        public int BerryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
