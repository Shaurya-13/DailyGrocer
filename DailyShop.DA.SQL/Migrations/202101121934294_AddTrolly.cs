namespace DailyShop.DA.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrolly : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrollyItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TrollyId = c.String(maxLength: 128),
                        ProductId = c.String(),
                        ProdQuantity = c.Int(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trollies", t => t.TrollyId)
                .Index(t => t.TrollyId);
            
            CreateTable(
                "dbo.Trollies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrollyItems", "TrollyId", "dbo.Trollies");
            DropIndex("dbo.TrollyItems", new[] { "TrollyId" });
            DropTable("dbo.Trollies");
            DropTable("dbo.TrollyItems");
        }
    }
}
