using System.ComponentModel.DataAnnotations;

namespace ProductList.Dal.Entities
{
    public class Product : IEntities
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual ProductCategory Category { get; set; }
    }
}
