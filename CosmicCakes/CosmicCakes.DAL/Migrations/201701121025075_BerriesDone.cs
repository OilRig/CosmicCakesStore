namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BerriesDone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Berries", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Berries");
        }
    }
}
