using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LiveShow.Dal.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task AddAsync(params TEntity[] entities);
        Task DeleteAsync(params TEntity[] entities);
        IAsyncEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task UpdateAsync(params TEntity[] entities);
    }
}
