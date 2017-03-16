namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogThemePost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogPosts", "Theme", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogPosts", "Theme");
        }
    }
}
