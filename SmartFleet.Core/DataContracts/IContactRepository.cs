using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartFleet.Entities;

namespace SmartFleet.Core.DataContracts
{
    public interface IContactRepository : IEntityRepository<Contact, Int32>
    {

    }
}
