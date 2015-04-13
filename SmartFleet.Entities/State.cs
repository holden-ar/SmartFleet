using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SmartFleet.Entities
{
    public class State
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int CountryId { get; set; }

        //Navigation 
        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
