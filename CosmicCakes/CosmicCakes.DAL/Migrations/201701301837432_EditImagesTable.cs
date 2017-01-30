namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditImagesTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SimpleCakeImages", new[] { "Path" });
            AddColumn("dbo.SimpleCakeImages", "PathPrefix", c => c.String(maxLength: 300));
            AddColumn("dbo.SimpleCakeImages", "FormatAbbreviation", c => c.String());
            CreateIndex("dbo.SimpleCakeImages", "PathPrefix", unique: true);
            DropColumn("dbo.SimpleCakeImages", "Path");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SimpleCakeImages", "Path", c => c.String(maxLength: 300));
            DropIndex("dbo.SimpleCakeImages", new[] { "PathPrefix" });
            DropColumn("dbo.SimpleCakeImages", "FormatAbbreviation");
            DropColumn("dbo.SimpleCakeImages", "PathPrefix");
            CreateIndex("dbo.SimpleCakeImages", "Path", unique: true);
        }
    }
}
