using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartFleet.Core.DataContracts;
using SmartFleet.Data;
using SmartFleet.Entities.Security;

namespace SmartFleet.Database.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly SmartFleetContext _context;
        public UserRepository(SmartFleetContext context)
        {
            _context = context;
        }
        IQueryable<User> IEntityRepository<User>.All
        {
            get { return _context.Users; }
        }

        IQueryable<User> IEntityRepository<User>.AllIncluding(params System.Linq.Expressions.Expression<Func<User, object>>[] includeProperties)
        {
            IQueryable<User> query = _context.Users;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        User IEntityRepository<User>.Find(int id)
        {
            //var entity = _context.Users.Find(id);
            var entity = _context.Users.Where(u => u.Id == id)
                    .Include(u=>u.Roles.Select(r=>r.Grants))
                    .FirstOrDefault();
            
            return entity;
        }

        void IEntityRepository<User>.InsertOrUpdate(User entity)
        {
            if (entity.Id == default(int))
            {
                // New entity
                _context.Users.Add(entity);
            }
            else
            {
                // Existing entity
                _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
        }

        void IEntityRepository<User>.Delete(int id)
        {
            var contact = _context.Users.Find(id);
            _context.Users.Remove(contact);
        }

        void IEntityRepository<User>.Save()
        {
            _context.SaveChanges();
        }

        void IDisposable.Dispose()
        {
            _context.Dispose();
        }
    }
}
