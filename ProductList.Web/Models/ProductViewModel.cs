using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductList.Web.Models
{
    public class ProductViewModel
    {
        [Key]
        [Display(Name = "Product Id")]
        public int Id { get; set; }

        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        [Display(Name = "Product category")]
        [Required(ErrorMessage = "Please enter a product category")]
        public int CategoryId { get; set; }

        public ProductCategoryViewModel Category { get; set; }
    }
}