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
        public int? StateId { get; set; }
        public int? SubstateId { get; set; }
        public Decimal Latitude{ get; set; }
        public Decimal Longitude{ get; set; }
        public DateTime ArrivedAt { get; set; }
        public string ContactName { get; set; }
        [StringLength(200)]
        public string ContactAddress { get; set; }
        [StringLength(25)]
        public string ContactPhone { get; set; }
        [StringLength(75)]
        public string ContactEmail { get; set; }
        
        //Navigation
        public virtual DispatchState State { get; set; }
        public virtual DispatchSubState Substate { get; set; }
        public virtual ICollection<DispatchItem> Items { get; set; }
        public virtual ICollection<Route> Routes { get; set; }          
    }
}
