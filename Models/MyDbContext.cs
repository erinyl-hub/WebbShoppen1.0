using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShoppen1._0.Models
{
    internal class MyDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Supplier> Supplier { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(a => a.EmailAdress).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(a => a.ProductName).IsUnique();
            modelBuilder.Entity<Supplier>().HasIndex(a => a.Name).IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=WebbShoppen1.0;Trusted_Connection=True; TrustServerCertificate=True");
            // optionsBuilder.UseSqlServer("Server=tcp:runedbase.database.windows.net,1433;Initial Catalog=RuneSys24;Persist Security Info=False;User ID=Rune;Password=*SystemTILL2026!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
