using System.Collections.Generic;

namespace CosmicCakes.Models
{
    public class CakeInfoModel
    {
        public CakeOrderDetails CakeOrderDitails { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double MinWeight { get; set; }
        public int MinPrice { get; set; }
        public int MaxWeight { get; set; }
        public int KgPrice { get; set; }
        public bool IsLevelable { get; set; }
        public IEnumerable<string> IndividualRectangleImagesPaths { get; set; }
        public IEnumerable<string> PriceIncludements { get; set; }
    }
    public class CakeOrderDetails
    {
        public IEnumerable<string> Bisquits { get; set; }
        public IEnumerable<string> Fillings { get; set; }
        public CakeOrderDetails()
        {
            Bisquits = new List<string>();
            Fillings = new List<string>();
        }
    }
}
