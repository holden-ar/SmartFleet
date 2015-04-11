using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartFleet.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
       

        //Navigation 
        public virtual ICollection<State> States { get; set; }
    }
}
