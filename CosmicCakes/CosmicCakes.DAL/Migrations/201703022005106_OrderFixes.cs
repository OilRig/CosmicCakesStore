namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderFixes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CakeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CakeName");
        }
    }
}
