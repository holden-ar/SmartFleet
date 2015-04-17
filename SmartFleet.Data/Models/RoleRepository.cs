using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartFleet.Core.DataContracts;
using SmartFleet.Data;

namespace SmartFleet.Database.Models
{
    public class RoleRepository : IRoleRepository
    {
       private readonly SmartFleetContext _context;
        public RoleRepository(SmartFleetContext context)
        {
            _context = context;
        }
        public IQueryable<Entities.Security.Role> All
        {
            get { return _context.Roles; }
        }

        public IQueryable<Entities.Security.Role> AllIncluding(params System.Linq.Expressions.Expression<Func<Entities.Security.Role, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Entities.Security.Role Find(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Entities.Security.Role entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
