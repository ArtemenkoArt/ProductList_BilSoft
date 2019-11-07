using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductList.Web.Models
{
    public class ProductCategoryViewModel
    {
        [ReadOnly(true)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductViewModel> Products { get; set; }

        public ProductCategoryViewModel()
        {
            Products = new List<ProductViewModel>();
        }
    }
}