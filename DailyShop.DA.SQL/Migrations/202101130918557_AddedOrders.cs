namespace DailyShop.DA.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrollyOrderItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TrollyOrderId = c.String(maxLength: 128),
                        ProductId = c.String(),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Img = c.String(),
                        OrderQuantity = c.Int(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrollyOrders", t => t.TrollyOrderId)
                .Index(t => t.TrollyOrderId);
            
            CreateTable(
                "dbo.TrollyOrders",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FName = c.String(),
                        LName = c.String(),
                        Email = c.String(),
                        City = c.String(),
                        State = c.String(),
                        TrollyOrderStatus = c.String(),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrollyOrderItems", "TrollyOrderId", "dbo.TrollyOrders");
            DropIndex("dbo.TrollyOrderItems", new[] { "TrollyOrderId" });
            DropTable("dbo.TrollyOrders");
            DropTable("dbo.TrollyOrderItems");
        }
    }
}
