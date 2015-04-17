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


        public IQueryable<User> All
        {
            get { return _context.Users; }
        }

        public IQueryable<User> AllIncluding(params System.Linq.Expressions.Expression<Func<User, object>>[] includeProperties)
        {
            IQueryable<User> query = _context.Users;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public User Find(int id)
        {
            var entity = _context.Users.Where(u => u.Id == id)
                   .Include(u => u.Roles.Select(r => r.Grants))
                   .FirstOrDefault();

            return entity;
        }

        public void InsertOrUpdate(User entity)
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

        public void Delete(int id)
        {
            var contact = _context.Users.Find(id);
            _context.Users.Remove(contact);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
