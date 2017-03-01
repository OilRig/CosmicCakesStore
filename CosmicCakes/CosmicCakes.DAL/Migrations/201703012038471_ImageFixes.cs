namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageFixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CakeIndividualSquareImages", "CakeId", "dbo.SimpleReadyCakes");
            DropIndex("dbo.CakeIndividualSquareImages", new[] { "CakeId" });
            DropTable("dbo.CakeIndividualSquareImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CakeIndividualSquareImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        CakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.CakeIndividualSquareImages", "CakeId");
            AddForeignKey("dbo.CakeIndividualSquareImages", "CakeId", "dbo.SimpleReadyCakes", "Id", cascadeDelete: true);
        }
    }
}
