namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CleaningDB : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AdditionalDecorations");
            DropTable("dbo.Berries");
            DropTable("dbo.CreamDecorarions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CreamDecorarions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DecoreType = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Berries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdditionalDecorations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
