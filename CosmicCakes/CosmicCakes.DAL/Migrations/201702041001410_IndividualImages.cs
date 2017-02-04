namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndividualImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CakeIndividualImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        CakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SimpleReadyCakes", t => t.CakeId, cascadeDelete: true)
                .Index(t => t.CakeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CakeIndividualImages", "CakeId", "dbo.SimpleReadyCakes");
            DropIndex("dbo.CakeIndividualImages", new[] { "CakeId" });
            DropTable("dbo.CakeIndividualImages");
        }
    }
}
