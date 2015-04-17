using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using SmartFleet.Core.BusinessContracts;
using SmartFleet.Core.DataContracts;
using SmartFleet.Entities.Security;

namespace SmartFleet.Business
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository ;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public List<User> GetPaged(int pageId, int pageSize)
        {
            var list = _repository.All.OrderBy(x=>x.Id).Skip(pageSize*pageId).Take(pageSize).ToList();
            return list;
        }

        public int Add(User user)
        {
            _repository.InsertOrUpdate(user);
            _repository.Save();
            return user.Id;
        }

        public User Find(int id)
        {
            return _repository.Find(id);
        }

        public void Edit(User entity)
        {
            _repository.InsertOrUpdate(entity);
            _repository.Save();
        }

        public void Delete(int id)
        {
           _repository.Delete(id);
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
