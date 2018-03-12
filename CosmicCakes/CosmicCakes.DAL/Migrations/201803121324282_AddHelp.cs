namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHelp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HelpRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 100),
                        Name = c.String(maxLength: 100),
                        Patronymic = c.String(maxLength: 100),
                        RequestText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HelpRequests");
        }
    }
}
