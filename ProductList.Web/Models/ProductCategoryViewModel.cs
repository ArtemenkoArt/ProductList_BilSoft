using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductList.Web.Models
{
    public class ProductCategoryViewModel
    {
        [Key]
        [Display(Name = "Category Id")]
        public int Id { get; set; }

        [Display(Name = "Category name")]
        [Required(ErrorMessage = "Please enter a ategory name")]
        public string Name { get; set; }
        public virtual ICollection<ProductViewModel> Products { get; set; }

        public ProductCategoryViewModel()
        {
            Products = new List<ProductViewModel>();
        }
    }
}