using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartFleet.WebApi.Models
{
    public class DispatchModel
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string ContactName { get; set; }
        public string ContactAddress { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public Decimal Latitude { get; set; }
        public Decimal Longitude { get; set; }
        public DateTime ArrivedAt { get; set; }
        public IEnumerable<DispatchItemModel> Items { get; set; }

    }
}
