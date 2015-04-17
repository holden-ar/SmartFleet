using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartFleet.Entities.Security;

namespace SmartFleet.Core.BusinessContracts
{
    public interface IRoleService
    {
        List<Role> GetAll();
        List<Role> GetPaged(int pageId, int pageSize);

        int Role(User user);

        void Edit(Role user);
        User Find(int id);

        void Delete(int id);
    }
}
