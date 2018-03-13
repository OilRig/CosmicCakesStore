namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActiveCake : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SimpleReadyCakes", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SimpleReadyCakes", "IsActive");
        }
    }
}
