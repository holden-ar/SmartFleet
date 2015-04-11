using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFleet.Entities
{
    public class Dispatch
    {
        public Dispatch()
        {
            Items = new List<DispatchItem>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Identifier { get; set; }
        public int SubstateId { get; set; }
        public int AddressId { get; set; }
        public DateTime ArrivedAt { get; set; }
        

        //Navigation
        public virtual DispatchSubState Substate { get; set; }
        public virtual ICollection<DispatchItem> Items { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public Address Address { get; set; }
    }
}
