
using System.Collections.Generic;

namespace CosmicCakes.Models
{
    public class CakeInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MainInfo { get; set; }
        public double MinWeight { get; set; }
        public decimal MinPrice => (decimal)MinWeight * KgPrice;
        public int MaxWeight { get; set; }
        public decimal KgPrice { get; set; }
        public bool IsLevelable { get; set; }

        public OrderModel CakeOrderModel { get; set; }

        public string[] IndividualRectangleImagesPaths { get; set; }
        public string[] PriceIncludements { get; set; }

    }
}
