using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SmartFleet.Entities.Security;

namespace SmartFleet.Web.Models
{
    public class UserAddEditViewModel
    {
        public UserAddEditViewModel()
        {
            Roles = new List<RoleViewModel>();
            SelectedRoles = new List<int>();
        }
        public int Id { get; set; }
        
        [Required]
        public string Username { get; set; }
       
        public string Passwd { get; set; }

        public string Email { get; set; }
        public bool Enabled { get; set; }
        public bool IsBuiltInUser { get; set; }

        public List<RoleViewModel> Roles { get; set; }
        public List<int> SelectedRoles { get; set; }
    }
}