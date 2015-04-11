using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace SmartFleet.Entities
{
    public class DispatchItem
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public decimal Quantity { get; set; }
    }
}
