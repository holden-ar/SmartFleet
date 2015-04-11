using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFleet.Entities
{
    public class Route
    {
        public Route()
        {
            Dispatches = new List<Dispatch>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TruckId { get; set; }
        public int DriverId { get; set; }
        
        //Navigation
        public virtual ICollection<Dispatch> Dispatches { get; set; }
        public virtual Truck Truck { get; set; }
        public virtual Driver Driver { get; set; }

        

    }
}
