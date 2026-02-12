using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Data
{
    public class ECommerceDbContext: IdentityDbContext<ApplicationUser>
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet <Category> Categories{ get; set; }
        public DbSet <Seller> Sellers { get; set; }
        public DbSet <ProductSeller> ProductSellers { get; set; }
        public DbSet<ProductDetailView> ProductDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<ProductSeller>().HasKey(ps => new { ps.ProductId, ps.SellerId });
            modelBuilder.Entity<ProductSeller>().HasOne(ps => ps.Product).WithMany(p => p.ProductSellers).HasForeignKey(ps => ps.ProductId);
            modelBuilder.Entity<ProductSeller>().HasOne(ps => ps.Seller).WithMany(s => s.ProductSellers).HasForeignKey(ps => ps.SellerId);
            modelBuilder.Entity<ProductDetailView>().HasNoKey().ToView("vw_ProductDetails");
            base.OnModelCreating(modelBuilder);
        }

    }
}
