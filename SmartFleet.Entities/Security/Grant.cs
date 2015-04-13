using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFleet.Entities.Security
{
    public class Grant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModuleId { get; set; }

        //Navigation
        public virtual Module Module { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
