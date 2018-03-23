using CosmicCakes.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCakes.DAL.Entities
{
    public class SweetIndividualRectangleImage : IHasIntegerId, IHasSweetForeignKey
    {
        public int Id { get; set; }

        [ForeignKey("AdditionalSweet")]
        public int SweetId { get; set; }
        public virtual Sweets.AdditionalSweet AdditionalSweet { get; set; }

        public string Path { get; set; }
    }
}
