namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoneEverything : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreamDecorarions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DecoreType = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CreamDecorarions");
        }
    }
}
