using ProductList.Dal.Entities;
using System.Data.Entity;

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
    }
}
