using AutoMapper;
using ProductList.Core.Models;
using ProductList.Core.Services.Contracts;
using ProductList.Dal.Entities;
using ProductList.Dal.Repositories.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductList.Core.Services.Implementations
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _repository;
        private readonly IMapper _mapper;

        public ProductCategoryService(IProductCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductCategoryCore> Add(ProductCategoryCore entity)
        {
            return _mapper.Map<ProductCategoryCore>(await _repository.Add(_mapper.Map<ProductCategory>(entity)));
        }

        public async Task Delete(ProductCategoryCore entity)
        {
            await _repository.Delete(_mapper.Map<ProductCategory>(entity));
        }

        public async Task<IEnumerable<ProductCategoryCore>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductCategoryCore>>(await _repository.GetAll());
        }

        public async Task<ProductCategoryCore> GetById(int Id)
        {
            return _mapper.Map<ProductCategoryCore>(await _repository.GetById(Id));
        }

        public async Task<IEnumerable<ProductCategoryCore>> GetItems(int pageSize = 10, int pageIndex = 0)
        {
            return _mapper.Map<IEnumerable<ProductCategoryCore>>(await _repository.GetItems(pageSize, pageIndex));
        }

        public async Task<ProductCategoryCore> Update(ProductCategoryCore entity)
        {
            return _mapper.Map<ProductCategoryCore>(await _repository.Update(_mapper.Map<ProductCategory>(entity)));
        }

        public async Task<int> Count()
        {
            return await _repository.Count();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
