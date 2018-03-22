using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmicCakes.Models
{
    public class SweetInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Info { get; set; }
        public decimal PricePerPcs { get; set; }
        public int MinPcsCount { get; set; }
    }
}