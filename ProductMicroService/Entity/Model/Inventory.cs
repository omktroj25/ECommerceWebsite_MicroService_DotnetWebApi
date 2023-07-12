using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    [Table("inventory")]
    public class Inventory : BaseEntity
    {
        [ForeignKey("product")]
        [Column("product_id")]
        public Guid ProductId { get; set; }
        [Column("stock")]
        public int Stock { get; set; }
        public virtual Product? Product { get; set; }
    }
}