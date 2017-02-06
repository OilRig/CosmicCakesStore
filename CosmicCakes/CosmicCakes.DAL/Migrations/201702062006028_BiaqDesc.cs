namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BiaqDesc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bisquits", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bisquits", "Description");
        }
    }
}
