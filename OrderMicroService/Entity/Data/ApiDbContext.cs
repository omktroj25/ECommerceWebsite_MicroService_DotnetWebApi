using Microsoft.EntityFrameworkCore;
using Entity.Model;

namespace Entity.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<Cart> Carts{get;set;} = null!;
        public virtual DbSet<CartItem> CartItems{get;set;} = null!;
        public virtual DbSet<Order> Orders{get;set;} = null!;
        public virtual DbSet<OrderItem> OrderItems{get;set;} = null!;
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

        }

    }    
}