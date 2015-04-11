using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartFleet.WebApi.Models
{
    public class DispatchItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
    }
}
