using CosmicCakes.DAL.Entities;
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

        }

        //custom order section
        public virtual DbSet<Bisquit> Bisquits { get; set; }
        public virtual DbSet<Cream> Cream { get; set; }
        public virtual DbSet<Filling> Fillings { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        //ready cake section
        public virtual DbSet<SimpleReadyCake> SimpleReadyCakes { get; set; }
        //Images section
        public virtual DbSet<SimpleCakeImage> SimpleCakeImages { get; set; }
        public virtual DbSet<CakeIndividualRectangleImage> CakeIndividualRectangleImages { get; set; }

        //priceIncludements section
        public virtual DbSet<IndividualPriceIncludement> IndividualCakePriceIncludements { get; set; }

        //Blog section
        public virtual DbSet<BlogPost> BlogPosts { get; set; }
        public virtual DbSet<PostContentTemplate> PostTemplates { get; set; }

        //Feedbacks
        public virtual DbSet<UserFeedback> UserFeedbacks { get; set; }

        //Subscribtions
        public virtual DbSet<UserSubscribtion> UserSubscriptions { get; set; }
    }
}
