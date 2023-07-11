using Microsoft.EntityFrameworkCore;
using Entity.Model;

namespace Entity.Data
{
    public class ApiDbContext : DbContext
    {

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

        }

    }    
}