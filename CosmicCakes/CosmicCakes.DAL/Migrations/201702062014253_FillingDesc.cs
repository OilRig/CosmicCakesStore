namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillingDesc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fillings", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fillings", "Description");
        }
    }
}
