namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoseparateleveledCakes : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.DoubleLeveledCakes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DoubleLeveledCakes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        MinWeight = c.Double(nullable: false),
                        KgPrice = c.Int(nullable: false),
                        IsLevelable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
