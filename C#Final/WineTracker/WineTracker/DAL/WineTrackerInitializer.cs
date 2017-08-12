using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations.Model;
using WineTracker.Models;

namespace WineTracker.DAL
{
    public class WineTrackerInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WineTrackerContext>
    {
        protected override void Seed(WineTrackerContext context)
        {
            var wines = new List<Wine>
            {
                new Wine {WineName = "Quailhurst Vineyard", Winery= "Dobbes" , Grape = "Pinot Noir", Quantity=1, Type= Wine.WineType.Red , Year=2010 },
                new Wine {WineName = "Hayward", Winery= "Folin", Grape = "Cabernet Franc", Quantity = 3, Type = Wine.WineType.Red, Year= 2013},
                new Wine {WineName = "Semillion", Winery= "Reinenger", Grape="Semillion", Quantity=2, Type= Wine.WineType.White, Year = 2013}
            };

            wines.ForEach(s => context.Wines.Add(s));
            context.SaveChanges();
        }
    }
}