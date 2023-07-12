using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    [Table("order_item")]
    public class OrderItem : BaseEntity
    {
        [ForeignKey("Order")]
        [Column("order_id")]
        public Guid OrderId { get; set; }
        [Column("product_id")]
        public Guid ProductId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        public virtual Order? Order { get; set; }
    }
}