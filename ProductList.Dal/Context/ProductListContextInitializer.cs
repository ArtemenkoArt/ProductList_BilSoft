using ProductList.Dal.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace ProductList.Dal.Context
{
    public class ProductListContextInitializer : DropCreateDatabaseIfModelChanges<ProductListContext>
    {
        protected override void Seed(ProductListContext db)
        {
            List<ProductCategory> categories = new List<ProductCategory>()
            {
                new ProductCategory { Name = "Catrgory 1" },
                new ProductCategory { Name = "Catrgory 2" },
                new ProductCategory { Name = "Catrgory 3" },
                new ProductCategory { Name = "Catrgory 4" }
            };

            foreach (var cat in categories)
            {
                db.ProductCategories.Add(cat);
                db.SaveChanges();
            }
        }
    }
}
