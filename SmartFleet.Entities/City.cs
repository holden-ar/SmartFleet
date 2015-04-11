using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartFleet.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }

        //Navigation 
        public virtual State State { get; set; }
    }
}
