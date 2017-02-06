using CosmicCakes.DAL.Entities;
using System.Collections.Generic;

namespace CosmicCakes.Models
{
    public class CakePartsModel
    {
        public IEnumerable<Cream> Creams { get; set; }
        public IEnumerable<Filling> Fillings { get; set; }
        public IEnumerable<Bisquit> Bisquits { get; set; }

        public CakePartsModel()
        {
            Creams = new List<Cream>();
            Fillings = new List<Filling>();
            Bisquits = new List<Bisquit>();
        }
    }
}
