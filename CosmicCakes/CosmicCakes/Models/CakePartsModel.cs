using CosmicCakes.DAL.Entities;
using System.Collections.Generic;

namespace CosmicCakes.Models
{
    public class CakePartsModel
    {
        public Cream[] Creams { get; set; }
        public Filling[] Fillings { get; set; }
        public Bisquit[] Bisquits { get; set; }
    }
}
