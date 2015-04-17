using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFleet.Core.BusinessContracts
{
    public interface IEntityService<T,K> : IDisposable
    {

        List<T> GetAll();

        List<T> GetPaged(int pageId, int pageSize);

        K Add(T entity);

        void Edit(T entity);
        T Find(K id);

        void Delete(K id);
    }
}
