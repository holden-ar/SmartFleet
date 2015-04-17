using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartFleet.Entities.Security;

namespace SmartFleet.Core.DataContracts
{
    public interface IUserRepository :IEntityRepository<User, Int32>
    {
    }
}
