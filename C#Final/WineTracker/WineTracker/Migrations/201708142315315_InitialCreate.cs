namespace WineTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wine",
                c => new
                    {
                        WineId = c.Int(nullable: false, identity: true),
                        WineName = c.String(),
                        Winery = c.String(),
                        Type = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Grape = c.String(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WineId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Wine");
        }
    }
}
