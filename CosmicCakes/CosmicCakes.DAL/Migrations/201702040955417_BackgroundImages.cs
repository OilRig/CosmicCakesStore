namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BackgroundImages : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SimpleCakeImages", newName: "SimpleCakeBackgroungImages");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SimpleCakeBackgroungImages", newName: "SimpleCakeImages");
        }
    }
}
