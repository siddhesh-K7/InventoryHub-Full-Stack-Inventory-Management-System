using InventoryHub.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryHub.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(p => p.SKU).IsUnique();
            
            // Seed Data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop Pro", Category = "Electronics", Price = 1200, Quantity = 15, Supplier = "TechCorp", SKU = "ELEC-001" },
                new Product { Id = 2, Name = "Ergonomic Chair", Category = "Furniture", Price = 250, Quantity = 3, Supplier = "OfficeSupplies Inc", SKU = "FURN-001" },
                new Product { Id = 3, Name = "Wireless Mouse", Category = "Accessories", Price = 45, Quantity = 50, Supplier = "TechCorp", SKU = "ACC-001" },
                new Product { Id = 4, Name = "Mechanical Keyboard", Category = "Accessories", Price = 100, Quantity = 20, Supplier = "KeyTech", SKU = "ACC-002" },
                new Product { Id = 5, Name = "Standing Desk", Category = "Furniture", Price = 500, Quantity = 0, Supplier = "OfficeSupplies Inc", SKU = "FURN-002" },
                new Product { Id = 6, Name = "USB-C Hub", Category = "Electronics", Price = 30, Quantity = 100, Supplier = "ConnectCo", SKU = "ELEC-002" },
                new Product { Id = 7, Name = "Printer Paper", Category = "Office Supplies", Price = 5, Quantity = 200, Supplier = "PaperMakers", SKU = "OFF-001" },
                new Product { Id = 8, Name = "Router", Category = "Networking", Price = 150, Quantity = 12, Supplier = "NetWorks", SKU = "NET-001" }
            );
        }
    }
}
