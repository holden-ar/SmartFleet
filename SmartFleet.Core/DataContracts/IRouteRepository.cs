using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartFleet.Entities;

namespace SmartFleet.Core.DataContracts
{
    public interface IRouteRepository
    {
        IQueryable<Route> GetRoutes(bool deepload=false);
        bool Add(Route route);
        bool AddDispatch(Dispatch dispatch);
        bool Update(Route entity);
        bool Delete(int id);
        bool Save();

        
    }
}
