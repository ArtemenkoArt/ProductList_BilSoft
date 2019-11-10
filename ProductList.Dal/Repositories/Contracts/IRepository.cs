using ProductList.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductList.Dal.Repositories.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<int> Delete(TEntity entity);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> GetById(int Id);
        Task<IEnumerable<TEntity>> GetBy(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetItems(int pageSize = 10, int pageIndex = 0);
        Task<int> Count();
        void Dispose();
    }
}
