namespace CosmicCakes.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class NoFKForCommonIncludement : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CommonPriceIncludements", "CakeId", "dbo.SimpleReadyCakes");
            DropIndex("dbo.CommonPriceIncludements", new[] { "CakeId" });

        }

        public override void Down()
        {
            AddColumn("dbo.CommonPriceIncludements", "CakeId", c => c.Int(nullable: false));
            CreateIndex("dbo.CommonPriceIncludements", "CakeId");
            AddForeignKey("dbo.CommonPriceIncludements", "CakeId", "dbo.SimpleReadyCakes", "Id", cascadeDelete: true);
        }
    }
}
