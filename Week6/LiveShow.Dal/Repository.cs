using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LiveShow.Dal
{
    internal class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly DbSet<T> dbSet;
        private readonly ApplicationDbContext dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.FirstOrDefaultAsync(predicate);
        }

        public IAsyncEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).AsAsyncEnumerable();
        }

        public IAsyncEnumerable<T> GetAll()
        {
            return dbSet.AsAsyncEnumerable();
        }

        public async Task AddAsync(params T[] entities)
        {
            await dbSet.AddRangeAsync(entities);

            await SaveChanges();
        }

        public async Task UpdateAsync(params T[] entities)
        {
            dbSet.UpdateRange(entities);

            await SaveChanges();
        }

        public async Task DeleteAsync(params T[] entities)
        {
            dbSet.RemoveRange(entities);

            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
