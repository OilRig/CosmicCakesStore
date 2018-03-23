using System.Collections.Generic;

namespace CosmicCakes.Models
{
    public class CakesStartPageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double MinWeight { get; set; }
        public decimal MinPrice => (decimal)MinWeight * KgPrice;
        public decimal KgPrice { get; set; }
        public string[] ImagePaths { get; set; }
        public string BackgroundImagePath { get; set; }
    }
}
