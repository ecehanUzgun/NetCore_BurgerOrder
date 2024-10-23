using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCore_BurgerOrder.Models.Entities;
using System.Reflection.Emit;

namespace NetCore_BurgerOrder.Models.Context
{
    public class ProjectContext:IdentityDbContext<AppUser, AppRole, int>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options):base(options)
        {
            
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Mapping

            //Order
            builder.Entity<Order>()
                .HasOne(x => x.AppUser)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.AppUserId);

            //OrderDetail Many to Many (Product Order)
            builder.Entity<OrderDetail>()
                .HasKey(x => new { x.OrderId, x.ProductId }); //Composite Key

            builder.Entity<OrderDetail>()
                .HasOne(x => x.Product)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.ProductId);

            builder.Entity<OrderDetail>()
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderId);

            builder.Entity<OrderDetail>().Property(x => x.UnitPrice).HasColumnType("decimal(18,4)");

            //Product
            builder.Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            builder.Entity<Product>().Property(x => x.UnitPrice).HasColumnType("decimal(18,4)");
        }   
    }
}
