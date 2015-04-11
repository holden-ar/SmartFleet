using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFleet.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Route> Routes { get; set; }
    }
}
