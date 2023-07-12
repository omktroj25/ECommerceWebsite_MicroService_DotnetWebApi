using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    [Table("payment")]
    public class Payment : BaseEntity
    {
        [ForeignKey("User")]
        [Column("user_id")]
        public Guid UserId { get; set; }
        [Column("payment_type")]
        public string PaymentType { get; set; }="";
        public virtual User? User { get; set; }
        public virtual UpiPayment? UpiPayment { get; set; }
        public virtual CardPayment? CardPayment { get; set; }
    }
}