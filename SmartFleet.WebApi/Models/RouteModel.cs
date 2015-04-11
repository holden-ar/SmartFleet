using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartFleet.Entities;

namespace SmartFleet.WebApi.Models
{
    public class RouteModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TruckId { get; set; }
        public int DriverId { get; set; }

        public TruckModel Truck { get; set; }
        public DriverModel Driver { get; set; }
        public IEnumerable<DispatchModel> Dispatches { get; set; }
    }
}