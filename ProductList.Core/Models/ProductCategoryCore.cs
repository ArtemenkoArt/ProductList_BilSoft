using System.Collections.Generic;
using System.ComponentModel;

namespace ProductList.Core.Models
{
    public class ProductCategoryCore
    {
        [ReadOnly(true)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductCore> Products { get; set; }

        public ProductCategoryCore()
        {
            Products = new List<ProductCore>();
        }
    }
}
