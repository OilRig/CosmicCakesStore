using CosmicCakes.DAL.Entities;
using CosmicCakes.DAL.Entities.Images;
using CosmicCakes.DAL.Entities.Inventory;
using CosmicCakes.DAL.Entities.Order;
using CosmicCakes.DAL.Entities.Pricing;
using CosmicCakes.DAL.Entities.Sweets;
using CosmicCakes.DAL.Migrations;
using System.Data.Entity;

namespace CosmicCakes.DAL
{

    public class CakeContext : DbContext
    {
        public CakeContext()
            : base("Cakes")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CakeContext, Configuration>("Cakes"));
            Configuration.ProxyCreationEnabled = false;
        }

        //custom order section
        public DbSet<Bisquit> Bisquits { get; set; }
        public DbSet<Cream> Cream { get; set; }
        public DbSet<Filling> Fillings { get; set; }
        public DbSet<Berry> Berries{ get; set; }

        public DbSet<Order> Orders { get; set; }

        //ready cake section
        public DbSet<CommonSweet> Sweets { get; set; }

        //Images section
        public  DbSet<SweetImage> SweetsImages { get; set; }
        public  DbSet<SweetIndividualRectangleImage> SweetsIndividualImages { get; set; }

        //priceIncludements section
        public  DbSet<IndividualPriceIncludement> IndividualCakePriceIncludements { get; set; }

        //Feedbacks
        public  DbSet<UserFeedback> UserFeedbacks { get; set; }

        //Help
        public  DbSet<HelpRequest> HelpRequests { get; set; }
    }
}
