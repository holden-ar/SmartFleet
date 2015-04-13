using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SmartFleet.Core.DataContracts;
using SmartFleet.Entities;
using SmartFleet.Data;

namespace SmartFleet.Database.Models
{ 
    public class ContactRepository : IContactRepository
    {
        private readonly SmartFleetContext context;

        public ContactRepository(SmartFleetContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Contact> All
        {
            get { return context.Contacts; }
        }

        public IQueryable<Contact> AllIncluding(params Expression<Func<Contact, object>>[] includeProperties)
        {
            IQueryable<Contact> query = context.Contacts;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Contact Find(int id)
        {
            return context.Contacts.Find(id);
        }

        public void InsertOrUpdate(Contact contact)
        {
            if (contact.Id == default(int)) {
                // New entity
                context.Contacts.Add(contact);
            } else {
                // Existing entity
                context.Entry(contact).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var contact = context.Contacts.Find(id);
            context.Contacts.Remove(contact);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }
    
}