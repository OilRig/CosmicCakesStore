namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeIssuesAndImprovements : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PriceIncludements", newName: "CommonPriceIncludements");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CommonPriceIncludements", newName: "PriceIncludements");
        }
    }
}
