using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartFleet.Web.Models
{
    public class UserAddEditModel
    {
        public int Id { get; set; }
        
        public string Username { get; set; }
       
        public string Passwd { get; set; }

        public string Email { get; set; }
        public bool Enabled { get; set; }
        public bool IsBuiltInUser { get; set; }

        //public List<Role> Roles { get; set; }
    }
}