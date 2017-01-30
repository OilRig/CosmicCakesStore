namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SimpleCakeImages",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        Path = c.String(maxLength: 300),
                        CakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.SimpleReadyCakes", t => t.CakeId, cascadeDelete: true)
                .Index(t => t.Path, unique: true)
                .Index(t => t.CakeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SimpleCakeImages", "CakeId", "dbo.SimpleReadyCakes");
            DropIndex("dbo.SimpleCakeImages", new[] { "CakeId" });
            DropIndex("dbo.SimpleCakeImages", new[] { "Path" });
            DropTable("dbo.SimpleCakeImages");
        }
    }
}
