using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFleet.Entities.Security
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(20)]
        public string Passwd { get; set; }
        [StringLength(60)]
        public string Email { get; set; }
        public bool Enabled { get; set; }
        public bool IsBuiltInUser { get; set; }
        //Navigation
        public virtual ICollection<Role> Roles { get; set; }

        public bool HasGrant(int id)
        {
            return Roles.SelectMany(r => r.Grants).Any(g => g.Id == id);
        }
    }
}
