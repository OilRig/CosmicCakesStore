namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MainInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SimpleReadyCakes", "MainInfo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SimpleReadyCakes", "MainInfo");
        }
    }
}
