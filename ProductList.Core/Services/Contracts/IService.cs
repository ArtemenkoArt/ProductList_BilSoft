using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductList.Core.Services.Contracts
{
    public interface IService<TModel> where TModel : class
    {
        Task Delete(TModel entity);
        Task<TModel> Add(TModel entity);
        Task<TModel> Update(TModel entity);
        Task<TModel> GetById(int Id);
        Task<IEnumerable<TModel>> GetAll();
        Task<IEnumerable<TModel>> GetItems(int pageSize = 10, int pageIndex = 1);
    }
}
