using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    [Table("cart_item")]
    public class CartItem : BaseEntity
    {
        [ForeignKey("Cart")]
        [Column("cart_id")]
        public Guid CartId { get; set; }
        [Column("product_id")]
        public Guid ProductId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        public virtual Cart? Cart { get; set; }
    }
}