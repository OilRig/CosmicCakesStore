namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesOnOrder2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "ExpireDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "ExpireDate", c => c.DateTime(nullable: false));
        }
    }
}
