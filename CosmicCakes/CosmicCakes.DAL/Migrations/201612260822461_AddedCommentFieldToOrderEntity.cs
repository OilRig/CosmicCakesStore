namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCommentFieldToOrderEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Comments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Comments");
        }
    }
}
