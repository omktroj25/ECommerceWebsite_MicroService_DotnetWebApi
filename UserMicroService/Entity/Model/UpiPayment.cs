using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    [Table("upi_payment")]
    public class UpiPayment : BaseEntity
    {
        [ForeignKey("Payment")]
        [Column("payment_type_id")]
        public Guid PaymentTypeId { get; set; }
        [Column("upi_id")]
        public string UpiId { get; set; }="";
        [Column("upi_app")]
        public string UpiApp { get; set; }="";
        public virtual Payment? Payment { get; set; }
    }
}