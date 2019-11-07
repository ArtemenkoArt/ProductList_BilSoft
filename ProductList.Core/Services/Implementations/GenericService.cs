using AutoMapper;
using ProductList.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductList.Core.Services.Implementations
{
    public class GenericService<TModel, TRepository> : IService<TModel> where TModel : class
    {
        private readonly TRepository _repository;
        private readonly IMapper _mapper;

        public GenericService(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<TModel> Add(TModel entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(TModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TModel> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TModel>> GetItems(int pageSize = 10, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> Update(TModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
