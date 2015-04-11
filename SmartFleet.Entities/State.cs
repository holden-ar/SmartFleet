using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartFleet.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        //Navigation 
        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
