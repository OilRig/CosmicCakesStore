namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactoring : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SimpleCakeImages");
            DropColumn("dbo.SimpleCakeImages", "ImageId");

            AddColumn("dbo.SimpleCakeImages", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.SimpleCakeImages", "Id");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.SimpleCakeImages", "ImageId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.SimpleCakeImages");
            DropColumn("dbo.SimpleCakeImages", "Id");
            AddPrimaryKey("dbo.SimpleCakeImages", "ImageId");
        }
    }
}
