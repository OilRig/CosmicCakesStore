using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CosmicCakes.DAL.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string CustomerName { get; set; }
        [StringLength(20)]
        public string CustomerPhoneNumber { get; set; }
        public DateTime OrderDate { get; set; }

        public DateTime ExpireDate { get; set; }
        [Range(1.5, 12)]
        public double CakeWeight { get; set; }
        public string BisquitType { get; set; }
        public string FillingType { get; set; }
        public string Comments { get; set; }
        public string Berries { get; set; }

    }
}
