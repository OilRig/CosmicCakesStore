namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CosmicCakes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Berries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bisquits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Creams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fillings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.IndividualPriceIncludements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IncludementInfo = c.String(),
                        SweetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommonSweets", t => t.SweetId, cascadeDelete: true)
                .Index(t => t.SweetId);
            
            CreateTable(
                "dbo.CommonSweets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 1000),
                        MainInfo = c.String(nullable: false, maxLength: 1000),
                        MinWeight = c.Double(nullable: false),
                        MinOrderItemsCount = c.Int(nullable: false),
                        PricePerItem = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxWeight = c.Int(nullable: false),
                        PricePerKilo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsLevelable = c.Boolean(nullable: false),
                        BackgroundImagePath = c.String(nullable: false, maxLength: 255),
                        IsActive = c.Boolean(nullable: false),
                        IsCake = c.Boolean(nullable: false),
                        IsAdditionalSweet = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        FillingType = c.String(),
                        Comments = c.String(),
                        Berries = c.String(),
                        CakeName = c.String(),
                        SelectedLevels = c.Int(nullable: false),
                        FirstLevelBisquit = c.String(),
                        SecondLevelBisquit = c.String(),
                        ThirdLevelBisquit = c.String(),
                        SelectedOneLevelBisquit = c.String(),
                        SelectedMultiLevelBisquit = c.String(),
                        DeliveryNeeded = c.Boolean(nullable: false),
                        DeliveryAdress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SweetImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        SweetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommonSweets", t => t.SweetId, cascadeDelete: true)
                .Index(t => t.SweetId);
            
            CreateTable(
                "dbo.SweetIndividualRectangleImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        SweetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommonSweets", t => t.SweetId, cascadeDelete: true)
                .Index(t => t.SweetId);
            
            CreateTable(
                "dbo.UserFeedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Content = c.String(),
                        Email = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        AttachedImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SweetIndividualRectangleImages", "SweetId", "dbo.CommonSweets");
            DropForeignKey("dbo.SweetImages", "SweetId", "dbo.CommonSweets");
            DropForeignKey("dbo.IndividualPriceIncludements", "SweetId", "dbo.CommonSweets");
            DropIndex("dbo.SweetIndividualRectangleImages", new[] { "SweetId" });
            DropIndex("dbo.SweetImages", new[] { "SweetId" });
            DropIndex("dbo.IndividualPriceIncludements", new[] { "SweetId" });
            DropTable("dbo.UserFeedbacks");
            DropTable("dbo.SweetIndividualRectangleImages");
            DropTable("dbo.SweetImages");
            DropTable("dbo.Orders");
            DropTable("dbo.CommonSweets");
            DropTable("dbo.IndividualPriceIncludements");
            DropTable("dbo.HelpRequests");
            DropTable("dbo.Fillings");
            DropTable("dbo.Creams");
            DropTable("dbo.Bisquits");
            DropTable("dbo.Berries");
        }
    }
}
