namespace WineTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Location : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wine", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Wine", "Location");
        }
    }
}
