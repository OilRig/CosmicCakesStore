namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sweets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalSweets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 64),
                        Description = c.String(maxLength: 200),
                        StartPricePerPcs = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdditionalSweets");
        }
    }
}
