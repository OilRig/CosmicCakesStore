namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FedbackEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserFeedbacks", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserFeedbacks", "Email");
        }
    }
}
