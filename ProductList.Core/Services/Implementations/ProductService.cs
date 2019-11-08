using AutoMapper;
using ProductList.Core.Models;
using ProductList.Core.Services.Contracts;
using ProductList.Dal.Entities;
using ProductList.Dal.Repositories.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductList.Core.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductCore> Add(ProductCore entity)
        {
            return _mapper.Map<ProductCore>(await _repository.Add(_mapper.Map<Product>(entity)));
        }

        public async Task Delete(ProductCore entity)
        {
            await _repository.Delete(_mapper.Map<Product>(entity));
        }

        public async Task<IEnumerable<ProductCore>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductCore>>(await _repository.GetAll());
        }

        public async Task<ProductCore> GetById(int Id)
        {
            return _mapper.Map<ProductCore>(await _repository.GetById(Id));
        }

        public async Task<IEnumerable<ProductCore>> GetItems(int pageSize = 10, int pageIndex = 0)
        {
            return _mapper.Map<IEnumerable<ProductCore>>(await _repository.GetItems(pageSize, pageIndex));
        }

        public async Task<ProductCore> Update(ProductCore entity)
        {
            return _mapper.Map<ProductCore>(await _repository.Update(_mapper.Map<Product>(entity)));
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
