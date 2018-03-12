namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropSubscriptions : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UserSubscribtions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserSubscribtions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Patronymic = c.String(),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
