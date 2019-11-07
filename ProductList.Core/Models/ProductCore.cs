using System.ComponentModel;

namespace ProductList.Core.Models
{
    public class ProductCore
    {
        [ReadOnly(true)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public ProductCategoryCore Category { get; set; }
    }
}
