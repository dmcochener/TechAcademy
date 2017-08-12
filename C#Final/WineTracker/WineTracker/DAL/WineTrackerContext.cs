using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineTracker.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WineTracker.DAL
{
    public class WineTrackerContext: DbContext
    {

            public WineTrackerContext() : base("WineTrackerContext")
            {
            }

            public DbSet<Wine> Wines { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
    }
}