namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FastOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FastOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SweetName = c.String(nullable: false),
                        CustomerName = c.String(nullable: false),
                        CustomerPhoneNumber = c.String(nullable: false),
                        CakeStringWeightOrItemsCount = c.String(nullable: false),
                        Comments = c.String(),
                        ExpireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FastOrders");
        }
    }
}
