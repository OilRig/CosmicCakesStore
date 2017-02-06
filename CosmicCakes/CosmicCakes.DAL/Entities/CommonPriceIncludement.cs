using System.ComponentModel.DataAnnotations;

namespace CosmicCakes.DAL.Entities
{
    public class CommonPriceIncludement
    {
        [Key]
        public int Id { get; set; }
        public string IncludementInfo { get; set; }
    }
}
