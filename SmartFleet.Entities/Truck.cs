using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFleet.Entities
{
    public class Truck
    {
        public int Id { get; set; }
        [StringLength(10)]
        public string Plate { get; set; }
    }
}
