using CosmicCakes.DAL.Entities;
using System.Data.Entity;

namespace CosmicCakes.DAL
{

    public class CakeContext : DbContext
    {
        public CakeContext()
            : base("name=Cakes")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CakeContext, Migrations.Configuration>("name=Cakes"));
        }

        public virtual DbSet<Berry> Berries { get; set; }
        public virtual DbSet<Bisquit> Bisquits { get; set; }
        public virtual DbSet<Cream> Cream { get; set; }
        public virtual DbSet<Filling> Fillings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
