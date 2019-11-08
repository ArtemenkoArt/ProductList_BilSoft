using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductList.Dal.Entities
{
    public class ProductCategory : IEntities
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<Product> Products { get; set; }

        //public ProductCategory()
        //{
        //    Products = new List<Product>();
        //}
    }
}
