using ProductList.Dal.Context;
using ProductList.Dal.Entities;
using ProductList.Dal.Repositories.Contracts;

namespace ProductList.Dal.Repositories.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductListContext context) : base(context) { }
    }
}
