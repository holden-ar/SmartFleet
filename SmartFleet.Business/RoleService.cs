using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartFleet.Core.BusinessContracts;
using SmartFleet.Core.DataContracts;
using SmartFleet.Entities.Security;

namespace SmartFleet.Business
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository ;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public List<Role> GetAll()
        {
            var list = _repository.All.ToList();
            return list;
        }


        public List<Role> GetPaged(int pageId, int pageSize)
        {
            throw new NotImplementedException();
        }

        public int Role(User user)
        {
            throw new NotImplementedException();
        }

        public void Edit(Role user)
        {
            throw new NotImplementedException();
        }

        public User Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
