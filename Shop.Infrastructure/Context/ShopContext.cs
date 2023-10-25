using Microsoft.EntityFrameworkCore;
using Shop.Domain.CategoryAgg;
using Shop.Domain.OrderAgg;
using Shop.Domain.Orders;
using Shop.Domain.ProductAgg;
using Shop.Domain.Products;
using Shop.Domain.UserAgg;

namespace Shop.Infrastructure.EF.Core.Context
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
        //    {
        //        relationship.DeleteBehavior = DeleteBehavior.Restrict;
        //    }

        //    base.OnModelCreating(modelBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().OwnsOne(b => b.Price, option =>
            {
                option.Property(b => b.RialValue)
                    .HasColumnName("RialPrice");
            });
            modelBuilder.Entity<Product>().OwnsOne(b => b.Money);
            modelBuilder.Entity<User>().OwnsOne(b => b.PhoneBook);

            base.OnModelCreating(modelBuilder);
        }
    }
}
