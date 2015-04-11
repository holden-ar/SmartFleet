using System;
using System.Data.Entity;
using SmartFleet.Entities;

namespace SmartFleet.Data
{
    public class SmartFleetContext : DbContext
    {
        public SmartFleetContext()
            : base("SmartFleet")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Dispatch> Dispatches { get; set; }
        public DbSet<Route> Routes { get; set; }
    }
}
 