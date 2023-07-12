using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    [Table("product")]
    public class Product : BaseEntity
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
        }

        [Column("product_name")]
        public string ProductName { get; set; }="";
        [Column("price")]
        [Range(0, double.PositiveInfinity, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }
        [Column("category")]
        public string Category { get; set; }="";
        [Column("description")]
        public string Description { get; set; }="";
        [Column("stock")]
        public int Stock { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}