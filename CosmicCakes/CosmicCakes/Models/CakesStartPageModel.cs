﻿using System.Collections.Generic;

namespace CosmicCakes.Models
{
    public class CakesStartPageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double MinWeight { get; set; }
        public int MinPrice { get; set; }
        public int KgPrice { get; set; }
        public IEnumerable<string> ImagePaths { get; set; }
        public string BackgroundImagePath { get; set; }
    }
}
