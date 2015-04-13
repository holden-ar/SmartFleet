using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SmartFleet.Entities
{
    public class City
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int StateId { get; set; }

        //Navigation 
        public virtual State State { get; set; }
    }
}
