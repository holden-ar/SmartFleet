using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFleet.Entities
{
    public class Address
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Street { get; set; }
        [StringLength(25)]
        public string Number { get; set; }
        [StringLength(15)]
        public string ZipCode { get; set; }

        public City City { get; set; }
        public Decimal Latitude { get; set; }
        public Decimal Longitude { get; set; }



    }
}
