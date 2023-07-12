using Microsoft.EntityFrameworkCore;
using Entity.Model;

namespace Entity.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<CardPayment> CardPayments{get;set;} = null!;
        public virtual DbSet<Address> Addresses{get;set;} = null!;
        public virtual DbSet<Wishlist> Wishlists{get;set;} = null!;
        public virtual DbSet<Payment> Payments{get;set;} = null!;
        public virtual DbSet<UpiPayment> UpiPayments{get;set;} = null!;
        public virtual DbSet<User> Users{get;set;} = null!;
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            Guid userId1 = new Guid("e56fa35f-042b-4d88-a165-9b14083c2872");
            Guid userId2 = new Guid("e71f575c-1c70-4f83-b8b0-8021a853b1ef");

            //Seeding data in the user table
            modelBuilder.Entity<User>().HasData(
                new User{
                    Id = userId1,
                    UserName = "AdminUser",
                    EmailAddress = "Admin@User.com",
                    PhoneNumber = "9087654321",
                    Password = "/3vZexp3id3Sd1Ei/WgX8xc2ctqfgCzuxX8oQyW/WJ8=", // Password@123
                    Role = "Admin",
                    CreatedBy = userId1,
                    UpdatedBy = userId1,
                },
                new User{
                    Id = userId2,
                    UserName = "Propel",
                    EmailAddress = "Propel@User.com",
                    PhoneNumber = "9012345678",
                    Password = "dM0p8PMqmscp69xac484T6OErIqk5WM4qDtV+MzVGdY=", // Propel@123
                    Role = "Admin",
                    CreatedBy = userId1,
                    UpdatedBy = userId1,
                }
            );

        }

    }    
}