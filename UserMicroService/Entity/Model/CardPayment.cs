using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    [Table("card_payment")]
    public class CardPayment : BaseEntity
    {
        [ForeignKey("Payment")]
        [Column("payment_type_id")]
        public Guid PaymentTypeId { get; set; }
        [Column("card_number")]
        public string CardNumber { get; set; }="";
        [Column("card_holder_name")]
        public string CardHolderName { get; set; }="";
        [Column("expire_date")]
        public string ExpireDate { get; set; }="";
        public virtual Payment? Payment { get; set; }
    
    }
}