namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BackgroundPathForCakes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SimpleReadyCakes", "BackgroundImagePath", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SimpleReadyCakes", "BackgroundImagePath");
        }
    }
}
