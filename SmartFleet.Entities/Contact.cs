using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFleet.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(25)]
        public string Phone { get; set; }
        [StringLength(75)]
        public string Email { get; set; }
        
        //Navigation
        public virtual ICollection<Dispatch> Dispatches { get; set; }
    }
}
