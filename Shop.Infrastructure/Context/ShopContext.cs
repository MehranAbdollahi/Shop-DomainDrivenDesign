using Microsoft.EntityFrameworkCore;
using Shop.Domain.CategoryAgg;
using Shop.Domain.OrderAgg;
using Shop.Domain.ProductAgg;
using Shop.Domain.UserAgg;

namespace Shop.Infrastructure.EF.Core.Context
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }


        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductImage> ProductImages { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

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
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Category>().Property(x => x.ParentId).IsRequired(false)
                .HasColumnType("int").HasColumnName("ParentId");

            base.OnModelCreating(modelBuilder);
        }
    }
}
