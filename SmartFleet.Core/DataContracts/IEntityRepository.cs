using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartFleet.Core.DataContracts
{
    public interface IEntityRepository<T,K> : IDisposable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(K id);
        void InsertOrUpdate(T entity);
        void Delete(K id);
        void Save();

    }
}
