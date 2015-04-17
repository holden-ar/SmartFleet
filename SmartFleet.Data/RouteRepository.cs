using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SmartFleet.Core.DataContracts;
using SmartFleet.Entities;

namespace SmartFleet.Data
{
    public class RouteRepository : IRouteRepository
    {
        private readonly SmartFleetContext _ctx;

        public RouteRepository(SmartFleetContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Route> GetRoutes(bool deepload=false)
        {
            var routes = _ctx.Routes;
            if (deepload)
            {
                routes 
                    .Include(r => r.Dispatches)
                    .Include(r => r.Driver)
                    .Include(r => r.Dispatches.Select(d => d.Items))
                    .Include(r => r.Truck);

            }
            return _ctx.Routes;
        }

        public bool AddDispatch(Dispatch dispatch)
        {
            try
            {
                _ctx.Dispatches.Add(dispatch);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Save()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Add(Route route)
        {
            try
            {
                _ctx.Routes.Add(route);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Route entity)
        {
            try
            {
                return UpdateEntity(_ctx.Routes, entity);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _ctx.Routes.FirstOrDefault(r => r.Id == id);
                if (entity != null) 
                {
                    _ctx.Routes.Remove(entity);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        bool UpdateEntity<T>(DbSet<T> dbSet, T entity) where T : class
        {
            try
            {
                dbSet.AttachAsModified(entity, _ctx);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
