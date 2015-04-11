using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SmartFleet.Entities
{
    public class DispatchSubState
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        
    }
}
