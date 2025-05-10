using BuyWise.Models.Products;
using Microsoft.EntityFrameworkCore;
using BuyWise.Models.Orders;
using BuyWise.Models.StaticEntities;


namespace BuyWise.Models
{
    public class BuyWiseDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use SQLite database
            optionsBuilder.UseSqlServer("Data Source=EHAB;Initial Catalog=BuyWise;Integrated Security=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
