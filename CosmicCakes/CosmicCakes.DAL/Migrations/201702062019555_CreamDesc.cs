namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreamDesc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cream", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cream", "Description");
        }
    }
}
