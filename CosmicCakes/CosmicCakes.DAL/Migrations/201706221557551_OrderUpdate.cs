namespace CosmicCakes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "SelectedLevels", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "FirstLevelBisquit", c => c.String());
            AddColumn("dbo.Orders", "SecondLevelBisquit", c => c.String());
            AddColumn("dbo.Orders", "ThirdLevelBisquit", c => c.String());
            AddColumn("dbo.Orders", "SelectedOneLevelBisquit", c => c.String());
            AddColumn("dbo.Orders", "SelectedMultiLevelBisquit", c => c.String());
            AddColumn("dbo.Orders", "DeliveryNeeded", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "DeliveryAdress", c => c.String());
            DropColumn("dbo.Orders", "BisquitType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "BisquitType", c => c.String());
            DropColumn("dbo.Orders", "DeliveryAdress");
            DropColumn("dbo.Orders", "DeliveryNeeded");
            DropColumn("dbo.Orders", "SelectedMultiLevelBisquit");
            DropColumn("dbo.Orders", "SelectedOneLevelBisquit");
            DropColumn("dbo.Orders", "ThirdLevelBisquit");
            DropColumn("dbo.Orders", "SecondLevelBisquit");
            DropColumn("dbo.Orders", "FirstLevelBisquit");
            DropColumn("dbo.Orders", "SelectedLevels");
        }
    }
}
