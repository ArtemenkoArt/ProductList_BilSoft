using ProductList.Dal.Entities;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace ProductList.Dal.Context
{
    public class ProductListContext : DbContext, IProductListContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        public ProductListContext() : base("conStrProductList")
        {
            Database.SetInitializer<ProductListContext>(new ProductListContextInitializer());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
