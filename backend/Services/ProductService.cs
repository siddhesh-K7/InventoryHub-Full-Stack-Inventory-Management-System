using InventoryHub.Data;
using InventoryHub.Models;
using InventoryHub.DTOs;
using Microsoft.EntityFrameworkCore;

namespace InventoryHub.Services
{
    public class ProductService : IProductService
    {
        private readonly InventoryDbContext _context;
        public ProductService(InventoryDbContext context) { _context = context; }

        public async Task<PaginatedResponse<Product>> GetProductsAsync(int page, int pageSize)
        {
            var totalItems = await _context.Products.CountAsync();
            var items = await _context.Products.AsNoTracking()
                .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedResponse<Product> { Items = items, Page = page, PageSize = pageSize, TotalItems = totalItems };
        }

        public async Task<Product?> GetProductByIdAsync(int id) => await _context.Products.FindAsync(id);

        public async Task<Product> CreateProductAsync(Product product)
        {
            product.CreatedAt = DateTime.UtcNow;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> UpdateProductAsync(int id, Product product)
        {
            var existing = await _context.Products.FindAsync(id);
            if (existing == null) return null;
            
            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Category = product.Category;
            existing.Price = product.Price;
            existing.Quantity = product.Quantity;
            existing.Supplier = product.Supplier;
            existing.SKU = product.SKU;
            existing.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string query) =>
            await _context.Products.AsNoTracking().Where(p => p.Name.Contains(query) || p.Category.Contains(query) || p.SKU.Contains(query)).ToListAsync();

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category) =>
            await _context.Products.AsNoTracking().Where(p => p.Category == category).ToListAsync();
    }
}
