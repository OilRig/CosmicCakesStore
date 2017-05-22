namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalMIgrationV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Theme = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CakeIndividualRectangleImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        CakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SimpleReadyCakes", t => t.CakeId, cascadeDelete: true)
                .Index(t => t.CakeId);
            
            CreateTable(
                "dbo.SimpleReadyCakes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        MinWeight = c.Double(nullable: false),
                        MinPrice = c.Int(nullable: false),
                        MaxWeight = c.Int(nullable: false),
                        KgPrice = c.Int(nullable: false),
                        IsLevelable = c.Boolean(nullable: false),
                        BackgroundImagePath = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SimpleCakeImages",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        CakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.SimpleReadyCakes", t => t.CakeId, cascadeDelete: true)
                .Index(t => t.CakeId);
            
            CreateTable(
                "dbo.IndividualPriceIncludements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IncludementInfo = c.String(),
                        CakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SimpleReadyCakes", t => t.CakeId, cascadeDelete: true)
                .Index(t => t.CakeId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(maxLength: 50),
                        CustomerPhoneNumber = c.String(maxLength: 20),
                        OrderDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        CakeWeight = c.Double(nullable: false),
                        BisquitType = c.String(),
                        FillingType = c.String(),
                        Comments = c.String(),
                        Berries = c.String(),
                        CakeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserFeedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Content = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Bisquits", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Cream", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Fillings", "Description", c => c.String(nullable: false));
            DropTable("dbo.Berries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Berries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.IndividualPriceIncludements", "CakeId", "dbo.SimpleReadyCakes");
            DropForeignKey("dbo.CakeIndividualRectangleImages", "CakeId", "dbo.SimpleReadyCakes");
            DropForeignKey("dbo.SimpleCakeImages", "CakeId", "dbo.SimpleReadyCakes");
            DropIndex("dbo.IndividualPriceIncludements", new[] { "CakeId" });
            DropIndex("dbo.SimpleCakeImages", new[] { "CakeId" });
            DropIndex("dbo.CakeIndividualRectangleImages", new[] { "CakeId" });
            DropColumn("dbo.Fillings", "Description");
            DropColumn("dbo.Cream", "Description");
            DropColumn("dbo.Bisquits", "Description");
            DropTable("dbo.UserFeedbacks");
            DropTable("dbo.Orders");
            DropTable("dbo.IndividualPriceIncludements");
            DropTable("dbo.SimpleCakeImages");
            DropTable("dbo.SimpleReadyCakes");
            DropTable("dbo.CakeIndividualRectangleImages");
            DropTable("dbo.BlogPosts");
        }
    }
}
