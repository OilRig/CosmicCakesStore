using CosmicCakes.DAL.Entities;
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
        public DbSet<SimpleReadyCake> SimpleReadyCakes { get; set; }

        public DbSet<AdditionalSweet> AdditionalSweets { get; set; }

        //Images section
        public  DbSet<SimpleCakeImage> SimpleCakeImages { get; set; }
        public  DbSet<CakeIndividualRectangleImage> CakeIndividualRectangleImages { get; set; }

        //priceIncludements section
        public  DbSet<IndividualPriceIncludement> IndividualCakePriceIncludements { get; set; }

        //Blog section
        public  DbSet<BlogPost> BlogPosts { get; set; }
        public  DbSet<PostContentTemplate> PostTemplates { get; set; }

        //Feedbacks
        public  DbSet<UserFeedback> UserFeedbacks { get; set; }

        //Emails
        public  DbSet<EmailTemplate> EmailTemplates { get; set; }
        public  DbSet<EmailLinkedResorce> LinkedResorces { get; set; }

        //Help
        public  DbSet<HelpRequest> HelpRequests { get; set; }
    }
}
