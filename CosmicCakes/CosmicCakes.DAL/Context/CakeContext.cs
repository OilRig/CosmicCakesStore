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


    }
}
