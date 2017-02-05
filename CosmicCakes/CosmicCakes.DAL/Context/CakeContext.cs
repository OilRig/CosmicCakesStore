using CosmicCakes.DAL.Entities;
using System.Data.Entity;

namespace CosmicCakes.DAL
{

    public class CakeContext : DbContext
    {
        public CakeContext()
            : base("Cakes")
        {

        }

        //custom order section
        public virtual DbSet<Berry> Berries { get; set; }
        public virtual DbSet<Bisquit> Bisquits { get; set; }
        public virtual DbSet<Cream> Cream { get; set; }
        public virtual DbSet<Filling> Fillings { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<CreamDecorarion> CreamDecorarions { get; set; }
        public virtual DbSet<AdditionalDecoration> AdditionalDecorations { get; set; }

        //ready cake section
        public virtual DbSet<SimpleReadyCake> SimpleReadyCakes { get; set; }
        //Images section
        public virtual DbSet<SimpleCakeImage> SimpleCakeImages { get; set; }
        public virtual DbSet<CakeIndividualSquareImage> CakeIndividualSquareImages { get; set; }
        public virtual DbSet<CakeIndividualRectangleImage> CakeIndividualRectangleImages { get; set; }

        //priceIncludements section
        public virtual DbSet<PriceIncludement> SimpleCakePriceIncludements { get; set; }

    }
}
