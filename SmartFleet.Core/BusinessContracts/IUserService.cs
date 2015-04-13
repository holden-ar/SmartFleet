using System.Collections.Generic;
using SmartFleet.Entities.Security;

namespace SmartFleet.Core.BusinessContracts
{
    public interface IUserService
    {

        List<User> GetPaged(int pageId, int pageSize);

        int Add(User user);

        void Edit(User user);
        User Find(int id);

        void Delete(int id);

    }
}