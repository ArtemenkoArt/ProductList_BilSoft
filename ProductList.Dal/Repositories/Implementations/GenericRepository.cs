using ProductList.Dal.Context;
using ProductList.Dal.Entities;
using ProductList.Dal.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductList.Dal.Repositories.Implementations
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntities
    {
        internal readonly ProductListContext _context;
        internal readonly DbSet<T> _dbSet;
        private bool disposed = false;

        public GenericRepository(ProductListContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetItems(int pageSize = 10, int pageIndex = 0)
        {
            var list = await _dbSet.OrderBy(x=> x.Id).Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();
            return list;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var list = await _dbSet.ToListAsync();
            return list;
        }

        public async Task<T> Add(T entity)
        {
            var result = _dbSet.Add(entity);
            await SaveChangesAsync();
            return result;
        }

        public virtual async Task<int> Delete(T entity)
        {
            _context.Set<T>().Remove(await GetById(entity.Id));
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<T> GetById(int Id)
        {
            return await _dbSet.FirstOrDefaultAsync(item => item.Id == Id);
        }

        public virtual async Task<IEnumerable<T>> GetBy(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<T> Update(T entity)
        {
            var existing = await _dbSet.FindAsync(entity.Id);

            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            return existing;
        }

        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
