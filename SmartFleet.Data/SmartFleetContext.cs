using System;
using System.Data.Entity;
using SmartFleet.Entities;
using SmartFleet.Entities.Security;

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


        #region Security
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Grant> Grants { get; set; } 
        #endregion

        #region Domailn
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Dispatch> Dispatches { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<DispatchState> DispatchStates { get; set; }
        public DbSet<DispatchSubState> DispatchSubStates { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        #endregion
    }
}
 