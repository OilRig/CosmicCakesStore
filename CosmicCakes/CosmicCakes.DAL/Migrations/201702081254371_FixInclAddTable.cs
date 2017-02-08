namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixInclAddTable : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.CommonPriceIncludements");
        }
    }
}
