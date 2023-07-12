using Microsoft.EntityFrameworkCore;
using Entity.Model;

namespace Entity.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<Product> Products{get;set;} = null!;
        public virtual DbSet<Inventory> Inventories{get;set;} = null!;
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            Guid userId1 = new Guid("e56fa35f-042b-4d88-a165-9b14083c2872"); //Admin user
            Guid userId2 = new Guid("e71f575c-1c70-4f83-b8b0-8021a853b1ef"); //Propel user

            Guid productId1 = Guid.NewGuid();
            Guid productId2 = Guid.NewGuid();
            Guid productId3 = Guid.NewGuid();
            Guid productId4 = Guid.NewGuid();
            Guid productId5 = Guid.NewGuid();
            Guid productId6 = Guid.NewGuid();
            Guid productId7 = Guid.NewGuid();
            Guid productId8 = Guid.NewGuid();
            Guid productId9 = Guid.NewGuid();
            Guid productId10 = Guid.NewGuid();
            Guid productId11 = Guid.NewGuid();
            Guid productId12 = Guid.NewGuid();
            Guid productId13 = Guid.NewGuid();
            Guid productId14 = Guid.NewGuid();
            Guid productId15 = Guid.NewGuid();
            Guid productId16 = Guid.NewGuid();
            Guid productId17 = Guid.NewGuid();
            Guid productId18 = Guid.NewGuid();
            Guid productId19 = Guid.NewGuid();
            Guid productId20 = Guid.NewGuid();
            Guid productId21 = Guid.NewGuid();
            Guid productId22 = Guid.NewGuid();
            Guid productId23 = Guid.NewGuid();
            Guid productId24 = Guid.NewGuid();
            Guid productId25 = Guid.NewGuid();
            Guid productId26 = Guid.NewGuid();
            Guid productId27 = Guid.NewGuid();
            Guid productId28 = Guid.NewGuid();
            Guid productId29 = Guid.NewGuid();
            Guid productId30 = Guid.NewGuid();
            Guid productId31 = Guid.NewGuid();
            Guid productId32 = Guid.NewGuid();
            Guid productId33 = Guid.NewGuid();
            Guid productId34 = Guid.NewGuid();
            Guid productId35 = Guid.NewGuid();
            Guid productId36 = Guid.NewGuid();
            Guid productId37 = Guid.NewGuid();
            Guid productId38 = Guid.NewGuid();
            Guid productId39 = Guid.NewGuid();
            Guid productId40 = Guid.NewGuid();
            Guid productId41 = Guid.NewGuid();
            Guid productId42 = Guid.NewGuid();
            Guid productId43 = Guid.NewGuid();
            Guid productId44 = Guid.NewGuid();
            Guid productId45 = Guid.NewGuid();
            Guid productId46 = Guid.NewGuid();
            Guid productId47 = Guid.NewGuid();
            Guid productId48 = Guid.NewGuid();
            Guid productId49 = Guid.NewGuid();
            Guid productId50 = Guid.NewGuid();

            //Seeding data in the product table
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = productId1,
                    ProductName = "Mobile Phone",
                    Price = 15000.0M,
                    Category = "Electronics",
                    Description = "4GB RAM 64GB ROM, 6.53-inch display",
                    Stock = 30,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId2,
                    ProductName = "Laptop",
                    Price = 50000.0M,
                    Category = "Electronics",
                    Description = "8GB RAM, 256GB SSD, 15.6-inch display",
                    Stock = 20,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId3,
                    ProductName = "Smart TV",
                    Price = 30000.0M,
                    Category = "Electronics",
                    Description = "43-inch 4K Ultra HD, Smart LED TV",
                    Stock = 15,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId4,
                    ProductName = "Men's Watch",
                    Price = 5000.0M,
                    Category = "Fashion",
                    Description = "Analog watch with leather strap",
                    Stock = 50,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId5,
                    ProductName = "Women's Handbag",
                    Price = 4000.0M,
                    Category = "Fashion",
                    Description = "Stylish handbag with multiple compartments",
                    Stock = 40,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId6,
                    ProductName = "Wireless Headphones",
                    Price = 3000.0M,
                    Category = "Electronics",
                    Description = "Bluetooth headphones with noise cancellation",
                    Stock = 25,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId7,
                    ProductName = "Sports Shoes",
                    Price = 2500.0M,
                    Category = "Fashion",
                    Description = "Running shoes with breathable mesh",
                    Stock = 60,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId8,
                    ProductName = "Fitness Tracker",
                    Price = 2000.0M,
                    Category = "Electronics",
                    Description = "Smart band with heart rate monitor",
                    Stock = 35,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId9,
                    ProductName = "Power Bank",
                    Price = 1500.0M,
                    Category = "Electronics",
                    Description = "10000mAh portable charger",
                    Stock = 45,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId10,
                    ProductName = "Cookware Set",
                    Price = 4000.0M,
                    Category = "Home & Kitchen",
                    Description = "Non-stick cookware set with lids",
                    Stock = 30,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId11,
                    ProductName = "Saree",
                    Price = 3000.0M,
                    Category = "Fashion",
                    Description = "Traditional Indian saree",
                    Stock = 20,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId12,
                    ProductName = "Bluetooth Speaker",
                    Price = 2500.0M,
                    Category = "Electronics",
                    Description = "Portable speaker with built-in microphone",
                    Stock = 50,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId13,
                    ProductName = "Mixer Grinder",
                    Price = 3500.0M,
                    Category = "Home & Kitchen",
                    Description = "550W mixer grinder with multiple jars",
                    Stock = 15,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId14,
                    ProductName = "Printed T-Shirt",
                    Price = 1000.0M,
                    Category = "Fashion",
                    Description = "Cotton t-shirt with a cool printed design",
                    Stock = 70,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId15,
                    ProductName = "External Hard Drive",
                    Price = 5000.0M,
                    Category = "Electronics",
                    Description = "1TB portable external hard drive",
                    Stock = 25,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId16,
                    ProductName = "Bed Sheets",
                    Price = 2000.0M,
                    Category = "Home & Kitchen",
                    Description = "Cotton bed sheets with pillow covers",
                    Stock = 40,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId17,
                    ProductName = "Men's Wallet",
                    Price = 1500.0M,
                    Category = "Fashion",
                    Description = "Genuine leather wallet with multiple card slots",
                    Stock = 60,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId18,
                    ProductName = "Air Purifier",
                    Price = 8000.0M,
                    Category = "Electronics",
                    Description = "HEPA filter air purifier for home",
                    Stock = 10,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId19,
                    ProductName = "Dinner Set",
                    Price = 3000.0M,
                    Category = "Home & Kitchen",
                    Description = "Opalware dinner set with plates and bowls",
                    Stock = 30,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId20,
                    ProductName = "Casual Shoes",
                    Price = 2000.0M,
                    Category = "Fashion",
                    Description = "Comfortable casual shoes for men",
                    Stock = 50,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId21,
                    ProductName = "Digital Camera",
                    Price = 25000.0M,
                    Category = "Electronics",
                    Description = "20MP DSLR camera with kit lens",
                    Stock = 15,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId22,
                    ProductName = "Women's Kurti",
                    Price = 1500.0M,
                    Category = "Fashion",
                    Description = "Stylish cotton kurti with embroidery",
                    Stock = 30,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId23,
                    ProductName = "Gaming Console",
                    Price = 30000.0M,
                    Category = "Electronics",
                    Description = "Latest gaming console with wireless controller",
                    Stock = 10,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId24,
                    ProductName = "Hand Blender",
                    Price = 1500.0M,
                    Category = "Home & Kitchen",
                    Description = "300W hand blender with multiple attachments",
                    Stock = 25,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId25,
                    ProductName = "Men's Formal Shirt",
                    Price = 2000.0M,
                    Category = "Fashion",
                    Description = "Cotton formal shirt with a slim fit",
                    Stock = 40,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Product
                {
                    Id = productId26,
                    ProductName = "Vacuum Cleaner",
                    Price = 5000.0M,
                    Category = "Home & Kitchen",
                    Description = "Robotic vacuum cleaner with automatic cleaning",
                    Stock = 20,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId27,
                    ProductName = "Bluetooth Earphones",
                    Price = 2000.0M,
                    Category = "Electronics",
                    Description = "Wireless earphones with charging case",
                    Stock = 30,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId28,
                    ProductName = "Kitchen Knife Set",
                    Price = 3000.0M,
                    Category = "Home & Kitchen",
                    Description = "High-quality stainless steel knife set",
                    Stock = 15,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId29,
                    ProductName = "Women's Sunglasses",
                    Price = 1500.0M,
                    Category = "Fashion",
                    Description = "Stylish sunglasses with UV protection",
                    Stock = 50,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId30,
                    ProductName = "Fitness Dumbbells",
                    Price = 2000.0M,
                    Category = "Sports & Fitness",
                    Description = "Set of adjustable dumbbells for home workouts",
                    Stock = 20,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId31,
                    ProductName = "Yoga Mat",
                    Price = 1000.0M,
                    Category = "Sports & Fitness",
                    Description = "Non-slip yoga mat with carrying strap",
                    Stock = 40,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId32,
                    ProductName = "Water Purifier",
                    Price = 10000.0M,
                    Category = "Home & Kitchen",
                    Description = "RO water purifier with multiple purification stages",
                    Stock = 10,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId33,
                    ProductName = "Men's Jeans",
                    Price = 2500.0M,
                    Category = "Fashion",
                    Description = "Denim jeans with a slim fit",
                    Stock = 30,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId34,
                    ProductName = "Portable Bluetooth Speaker",
                    Price = 3000.0M,
                    Category = "Electronics",
                    Description = "Waterproof speaker with built-in microphone",
                    Stock = 25,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId35,
                    ProductName = "Cotton Bedsheets",
                    Price = 2000.0M,
                    Category = "Home & Kitchen",
                    Description = "Soft cotton bed sheets with floral print",
                    Stock = 40,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId36,
                    ProductName = "Men's Formal Shoes",
                    Price = 4000.0M,
                    Category = "Fashion",
                    Description = "Leather formal shoes with lace-up closure",
                    Stock = 30,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId37,
                    ProductName = "Air Fryer",
                    Price = 5000.0M,
                    Category = "Home & Kitchen",
                    Description = "Healthy cooking with less oil",
                    Stock = 15,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId38,
                    ProductName = "Wireless Mouse",
                    Price = 1000.0M,
                    Category = "Electronics",
                    Description = "Ergonomic wireless mouse with USB receiver",
                    Stock = 50,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId39,
                    ProductName = "Men's Shorts",
                    Price = 1500.0M,
                    Category = "Fashion",
                    Description = "Casual shorts for a comfortable summer look",
                    Stock = 60,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId40,
                    ProductName = "Water Bottle",
                    Price = 500.0M,
                    Category = "Home & Kitchen",
                    Description = "Stainless steel water bottle with double insulation",
                    Stock = 70,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId41,
                    ProductName = "Power Drill",
                    Price = 3000.0M,
                    Category = "Tools & Home Improvement",
                    Description = "Cordless power drill with multiple drill bits",
                    Stock = 20,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId42,
                    ProductName = "School Backpack",
                    Price = 2000.0M,
                    Category = "Fashion",
                    Description = "Durable backpack with multiple compartments",
                    Stock = 30,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId43,
                    ProductName = "Printer",
                    Price = 8000.0M,
                    Category = "Electronics",
                    Description = "Wireless all-in-one printer for home or office",
                    Stock = 10,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId44,
                    ProductName = "Cooking Utensil Set",
                    Price = 2500.0M,
                    Category = "Home & Kitchen",
                    Description = "Stainless steel cooking utensils with hanging rack",
                    Stock = 25,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId45,
                    ProductName = "Men's Sweatshirt",
                    Price = 1500.0M,
                    Category = "Fashion",
                    Description = "Comfortable sweatshirt for a casual look",
                    Stock = 40,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId46,
                    ProductName = "Rice Cooker",
                    Price = 3000.0M,
                    Category = "Home & Kitchen",
                    Description = "Automatic rice cooker with multiple cooking modes",
                    Stock = 20,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId47,
                    ProductName = "Wireless Keyboard",
                    Price = 2000.0M,
                    Category = "Electronics",
                    Description = "Slim wireless keyboard with ergonomic design",
                    Stock = 30,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId48,
                    ProductName = "Wall Clock",
                    Price = 1000.0M,
                    Category = "Home & Kitchen",
                    Description = "Modern wall clock with silent movement",
                    Stock = 50,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId49,
                    ProductName = "Men's Polo T-Shirt",
                    Price = 1500.0M,
                    Category = "Fashion",
                    Description = "Classic polo t-shirt with a stylish design",
                    Stock = 60,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Product
                {
                    Id = productId50,
                    ProductName = "Bluetooth Car Kit",
                    Price = 2000.0M,
                    Category = "Electronics",
                    Description = "Hands-free car kit with Bluetooth connectivity",
                    Stock = 25,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                }
             );

            //Seeding data in the product table
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId1,
                    Stock = 30,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId2,
                    Stock = 20,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId3,
                    Stock = 15,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId4,
                    Stock = 50,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId5,
                    Stock = 40,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId6,
                    Stock = 25,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId7,
                    Stock = 60,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId8,
                    Stock = 35,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId9,
                    Stock = 45,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId10,
                    Stock = 30,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId11,
                    Stock = 20,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId12,
                    Stock = 50,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId13,
                    Stock = 15,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId14,
                    Stock = 70,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId15,
                    Stock = 25,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId16,
                    Stock = 40,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId17,
                    Stock = 60,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId18,
                    Stock = 10,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId19,
                    Stock = 30,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId20,
                    Stock = 50,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId21,
                    Stock = 15,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId22,
                    Stock = 30,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId23,
                    Stock = 10,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId24,
                    Stock = 25,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId25,
                    Stock = 40,
                    CreatedBy = userId1,
                    UpdatedBy = userId1
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId26,
                    Stock = 20,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId27,
                    Stock = 30,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId28,
                    Stock = 15,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId29,
                    Stock = 50,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId30,
                    Stock = 20,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId31,
                    Stock = 40,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId32,
                    Stock = 10,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId33,
                    Stock = 30,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId34,
                    Stock = 25,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId35,
                    Stock = 40,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId36,
                    Stock = 30,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId37,
                    Stock = 15,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId38,
                    Stock = 50,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId39,
                    Stock = 60,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId40,
                    Stock = 70,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId41,
                    Stock = 20,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId42,
                    Stock = 30,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId43,
                    Stock = 10,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId44,
                    Stock = 25,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId45,
                    Stock = 40,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId46,
                    Stock = 20,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId47,
                    Stock = 30,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId48,
                    Stock = 50,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId49,
                    Stock = 60,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                },
                new Inventory
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId50,
                    Stock = 25,
                    CreatedBy = userId2,
                    UpdatedBy = userId2
                }

            );

        }

    }    
}