using System.Collections.Generic;

namespace ProductList.Web.Models
{
    public class ProductCategoryListViewModel
    {
        public IEnumerable<ProductCategoryViewModel> Categories { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}