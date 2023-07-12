using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    [Table("wishlist")]
    public class Wishlist : BaseEntity
    {
        [ForeignKey("User")]
        [Column("user_id")]
        public Guid UserId { get; set; }
        [Column("product_id")]
        public Guid ProductId { get; set; }
        public virtual User? User { get; set; }
    }
}