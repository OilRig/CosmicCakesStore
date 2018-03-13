using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CosmicCakes.DAL.Common;

namespace CosmicCakes.DAL.Entities
{
    public class IndividualPriceIncludement : IHasIntegerId, IHasCakeForeignKey
    {
        [Key]
        public int Id { get; set; }
        public string IncludementInfo { get; set; }

        [ForeignKey("SimpleReadyCake")]
        public int CakeId { get; set; }
        public virtual SimpleReadyCake SimpleReadyCake { get; set; }
    }
}
