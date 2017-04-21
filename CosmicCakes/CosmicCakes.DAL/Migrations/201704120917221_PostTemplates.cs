namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostTemplates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostContentTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PostContentTemplates");
        }
    }
}
