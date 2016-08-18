using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CodemashApp.Interfaces
{
    public interface IWebRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(string id);
        IEnumerable<T> GetRecords(string data);
        void Dispose();
    }
}