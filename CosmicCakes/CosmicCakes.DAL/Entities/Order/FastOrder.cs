using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmicCakes.DAL.Common;

namespace CosmicCakes.DAL.Entities.Order
{
    public class FastOrder : IHasIntegerId
    {
        [Required]
        public string SweetName { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerPhoneNumber { get; set; }

        [Required]
        public string CakeStringWeightOrItemsCount { get; set; }

        public string Comments { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        [Key]
        public int Id { get; set; }
    }
}
