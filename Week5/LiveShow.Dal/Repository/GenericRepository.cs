using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LiveShow.Dal.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> dbSet;
        private readonly ApplicationDbContext dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.FirstOrDefaultAsync(predicate);
        }

        public IAsyncEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate).AsAsyncEnumerable();
        }

        public async Task AddAsync(params TEntity[] entities)
        {
            await dbSet.AddRangeAsync(entities);

            await SaveChanges();
        }

        public async Task UpdateAsync(params TEntity[] entities)
        {
            dbSet.UpdateRange(entities);

            await SaveChanges();
        }

        public async Task DeleteAsync(params TEntity[] entities)
        {
            dbSet.RemoveRange(entities);

            await SaveChanges();
        }

        private async Task SaveChanges()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
