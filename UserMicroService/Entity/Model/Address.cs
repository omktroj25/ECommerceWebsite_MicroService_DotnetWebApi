using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    [Table("address")]
    public class Address : BaseEntity
    {
        [ForeignKey("User")]
        [Column("user_id")]
        public Guid UserId { get; set; }
        [Column("line1")]
        public string Line1 { get; set; }="";
        [Column("line2")]
        public string Line2 { get; set; }="";
        [Column("city")]
        public string City { get; set; }="";
        [Column("state")]
        public string State { get; set; }="";
        [Column("country")]
        public string Country { get; set; }="";
        [Column("zip_code")]
        public string ZipCode { get; set; }="";
        [Column("phone_number")]
        public string PhoneNumber { get; set; }="";
        [Column("address_type")]
        public string AddressType { get; set; }="";
        public virtual User? User { get; set; }
    }
}