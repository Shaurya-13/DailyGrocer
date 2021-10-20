namespace DailyShop.DA.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConsumer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consumers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ConsumerId = c.String(),
                        FName = c.String(),
                        LName = c.String(),
                        Email = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Consumers");
        }
    }
}
