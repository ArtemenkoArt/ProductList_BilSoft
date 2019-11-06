using ProductList.Dal.Context;
using ProductList.Dal.Entities;
using ProductList.Dal.Repositories.Contracts;

namespace ProductList.Dal.Repositories.Implementations
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ProductListContext context) : base(context) { }
    }
}
