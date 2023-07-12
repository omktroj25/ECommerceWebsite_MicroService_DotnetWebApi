using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    [Table("cart")]
    public class Cart : BaseEntity
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }

        [Column("user_id")]
        public Guid UserId { get; set; }
        public virtual Order? Order { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}