namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailResourses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailLinkedResorces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailTemplateId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 64),
                        Content = c.Binary(),
                        ContentType = c.String(maxLength: 64),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmailTemplates", t => t.EmailTemplateId)
                .Index(t => t.EmailTemplateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmailLinkedResorces", "EmailTemplateId", "dbo.EmailTemplates");
            DropIndex("dbo.EmailLinkedResorces", new[] { "EmailTemplateId" });
            DropTable("dbo.EmailLinkedResorces");
        }
    }
}
