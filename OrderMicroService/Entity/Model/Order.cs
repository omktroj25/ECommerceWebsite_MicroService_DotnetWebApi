using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    [Table("order")]
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        [Column("user_id")]
        public Guid UserId { get; set; }
        [Column("payment_id")]
        public Guid PaymentId { get; set; }
        [Column("address_id")]
        public Guid AddressId { get; set; }
        [Column("cart_id")]
        public Guid CartId { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual Cart? Cart { get; set; }
    }
}