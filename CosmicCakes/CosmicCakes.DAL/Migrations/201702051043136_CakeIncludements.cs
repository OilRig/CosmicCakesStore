namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CakeIncludements : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceIncludements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IncludementInfo = c.String(),
                        CakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SimpleReadyCakes", t => t.CakeId, cascadeDelete: true)
                .Index(t => t.CakeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PriceIncludements", "CakeId", "dbo.SimpleReadyCakes");
            DropIndex("dbo.PriceIncludements", new[] { "CakeId" });
            DropTable("dbo.PriceIncludements");
        }
    }
}
