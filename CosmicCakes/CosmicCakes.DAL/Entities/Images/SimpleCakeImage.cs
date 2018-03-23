using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CosmicCakes.DAL.Common;

namespace CosmicCakes.DAL.Entities.Images
{
    public class SweetImage : IHasIntegerId, IHasSweetForeignKey
    {
        [Key]
        public int Id { get; set; }

        public string Path { get; set; }

        [ForeignKey("CommonSweet")]
        public int SweetId { get; set; }
        public virtual CommonSweet CommonSweet { get; set; }
    }
}
