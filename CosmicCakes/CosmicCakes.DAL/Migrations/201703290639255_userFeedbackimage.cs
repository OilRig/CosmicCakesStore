namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userFeedbackimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserFeedbacks", "AttachedImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserFeedbacks", "AttachedImagePath");
        }
    }
}
