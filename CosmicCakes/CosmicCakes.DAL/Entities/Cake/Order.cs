using System;
using System.ComponentModel.DataAnnotations;
using CosmicCakes.DAL.Common;

namespace CosmicCakes.DAL.Entities
{
    public class Order : IHasIntegerId
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
        public string FillingType { get; set; }
        public string Comments { get; set; }
        public string Berries { get; set; }
        public string CakeName { get; set; }
        public int SelectedLevels { get; set; }
        public string FirstLevelBisquit { get; set; }
        public string SecondLevelBisquit { get; set; }
        public string ThirdLevelBisquit { get; set; }
        public string SelectedOneLevelBisquit { get; set; }
        public string SelectedMultiLevelBisquit { get; set; }
        public bool DeliveryNeeded { get; set; }
        public string DeliveryAdress { get; set; }
    }
}
