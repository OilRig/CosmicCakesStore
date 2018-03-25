using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmicCakes.Models
{
    public class SweetsAggregatedModel
    {
        public SweetModel[] Sweets { get; set; }
        
    }
    public class SweetModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal StartPricePerPcs { get; set; }
        public string[] ImagePaths { get; set; }
    }
}