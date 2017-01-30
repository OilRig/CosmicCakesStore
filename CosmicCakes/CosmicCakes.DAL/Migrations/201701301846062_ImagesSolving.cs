namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagesSolving : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SimpleCakeImages", new[] { "PathPrefix" });
            AddColumn("dbo.SimpleCakeImages", "Path", c => c.String());
            DropColumn("dbo.SimpleCakeImages", "PathPrefix");
            DropColumn("dbo.SimpleCakeImages", "FormatAbbreviation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SimpleCakeImages", "FormatAbbreviation", c => c.String());
            AddColumn("dbo.SimpleCakeImages", "PathPrefix", c => c.String(maxLength: 300));
            DropColumn("dbo.SimpleCakeImages", "Path");
            CreateIndex("dbo.SimpleCakeImages", "PathPrefix", unique: true);
        }
    }
}
