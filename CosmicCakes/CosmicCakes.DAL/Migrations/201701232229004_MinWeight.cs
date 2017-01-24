namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinWeight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SimpleReadyCakes", "MinWeight", c => c.Double(nullable: false));
            DropColumn("dbo.SimpleReadyCakes", "Weight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SimpleReadyCakes", "Weight", c => c.Double(nullable: false));
            DropColumn("dbo.SimpleReadyCakes", "MinWeight");
        }
    }
}
