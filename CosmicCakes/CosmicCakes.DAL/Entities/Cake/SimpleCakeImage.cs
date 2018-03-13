using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CosmicCakes.DAL.Common;

namespace CosmicCakes.DAL.Entities
{
    public class SimpleCakeImage : IHasIntegerId, IHasCakeForeignKey
    {
        [Key]
        public int Id { get; set; }

        public string Path { get; set; }

        [ForeignKey("SimpleReadyCake")]
        public int CakeId { get; set; }
        public virtual SimpleReadyCake SimpleReadyCake { get; set; }
    }
}
