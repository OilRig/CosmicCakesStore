namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Improvement : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SimpleCakeBackgroungImages", newName: "SimpleCakeImages");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SimpleCakeImages", newName: "SimpleCakeBackgroungImages");
        }
    }
}
