using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFleet.Entities.Security
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation
        public virtual ICollection<Grant> Grants { get; set; }
    }
}
