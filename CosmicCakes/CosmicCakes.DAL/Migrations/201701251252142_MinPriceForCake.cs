namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinPriceForCake : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SimpleReadyCakes", "MinPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SimpleReadyCakes", "MinPrice");
        }
    }
}
