using CosmicCakes.DAL.Entities;
using System.Data.Entity;

namespace CosmicCakes.DAL
{
    public class CakeContext : DbContext
    {
        public CakeContext() : base("CosmicCakes")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CakeContext, Migrations.Configuration>("CrawlingData"));
            Database.SetInitializer(new DropCreateDatabaseAlways<CakeContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Bisquit> Bisquits { get; set; }
        public DbSet<Filling> Fillings { get; set; }
        public DbSet<Berry> Berries { get; set; }
        public DbSet<Decoration> Decorations { get; set; }
        public DbSet<Order> Orders { get; set; }




    }
}
