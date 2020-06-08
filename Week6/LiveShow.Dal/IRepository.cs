using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LiveShow.Dal
{
    public interface IRepository<T>
        where T : class
    {
        Task AddAsync(params T[] entities);
        Task DeleteAsync(params T[] entities);
        IAsyncEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        IAsyncEnumerable<T> GetAll();
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task UpdateAsync(params T[] entities);
        Task SaveChanges();
    }
}