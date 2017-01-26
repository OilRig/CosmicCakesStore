namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxWeightAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SimpleReadyCakes", "MaxWeight", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SimpleReadyCakes", "MaxWeight");
        }
    }
}
