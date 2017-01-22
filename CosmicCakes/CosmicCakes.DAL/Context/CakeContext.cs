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

        public virtual DbSet<Berry> Berries { get; set; }
        public virtual DbSet<Bisquit> Bisquits { get; set; }
        public virtual DbSet<Cream> Cream { get; set; }
        public virtual DbSet<Filling> Fillings { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<CreamDecorarion> CreamDecorarions { get; set; }
        public virtual DbSet<AdditionalDecoration> AdditionalDecorations { get; set; }
    }
}
