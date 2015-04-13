using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFleet.Entities.Security
{
    public class Role
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public bool IsBuiltInRole { get; set; }
        //Navigation
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Grant> Grants { get; set; }
    }
}
