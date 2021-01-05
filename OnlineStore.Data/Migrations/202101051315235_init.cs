namespace OnlineStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.ItemOrders",
                c => new
                    {
                        ItemOrderId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemOrderId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        DeliveryAddress = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemOrders", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemOrders", "OrderId", "dbo.Orders");
            DropIndex("dbo.ItemOrders", new[] { "ItemId" });
            DropIndex("dbo.ItemOrders", new[] { "OrderId" });
            DropTable("dbo.Orders");
            DropTable("dbo.ItemOrders");
            DropTable("dbo.Items");
        }
    }
}
