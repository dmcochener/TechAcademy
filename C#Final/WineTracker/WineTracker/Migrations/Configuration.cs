namespace WineTracker.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WineTracker.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WineTracker.DAL.WineTrackerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WineTracker.DAL.WineTrackerContext";
        }

        protected override void Seed(WineTracker.DAL.WineTrackerContext context)
        {
            new Wine { WineName = "Quailhurst Vineyard", Winery = "Dobbes", Grape = "Pinot Noir", Quantity = 1, Type = Wine.WineType.Red, Year = 2010, Location = "Living Room"};
            new Wine { WineName = "Hayward", Winery = "Folin", Grape = "Cabernet Franc", Quantity = 3, Type = Wine.WineType.Red, Year = 2013, Location = "Storage Unit" };
            new Wine { WineName = "Semillion", Winery = "Reinenger", Grape = "Semillion", Quantity = 2, Type = Wine.WineType.White, Year = 2013, Location = "Kitchen"};
        }
    }
}
