namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SquareAndRectangleImages : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CakeIndividualImages", newName: "CakeIndividualRectangleImages");
            CreateTable(
                "dbo.CakeIndividualSquareImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        CakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CakeId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CakeIndividualSquareImages", new[] { "CakeId" });
            DropTable("dbo.CakeIndividualSquareImages");
            RenameTable(name: "dbo.CakeIndividualRectangleImages", newName: "CakeIndividualImages");
        }
    }
}
