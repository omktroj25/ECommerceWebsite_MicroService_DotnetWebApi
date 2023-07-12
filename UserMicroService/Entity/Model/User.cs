using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    [Table("user")]
    public class User : BaseEntity
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            Payments = new HashSet<Payment>();
            Wishlists = new HashSet<Wishlist>();
        }

        [Column("user_name")]
        public string UserName { get; set; }="";
        [Column("email_address")]
        public string EmailAddress { get; set; }="";
        [Column("phone_number")]
        public string PhoneNumber { get; set; }="";
        [Column("password")]
        public string Password { get; set; }="";
        [Column("role")]
        public string Role { get; set; }="User";
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
        
    }
}