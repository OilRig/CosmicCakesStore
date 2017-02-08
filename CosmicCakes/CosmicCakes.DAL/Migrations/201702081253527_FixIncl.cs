namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixIncl : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CommonPriceIncludements");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CommonPriceIncludements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IncludementInfo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
