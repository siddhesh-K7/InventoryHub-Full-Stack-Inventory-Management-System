using InventoryHub.Models;
using InventoryHub.DTOs;

namespace InventoryHub.Services
{
    public interface IProductService
    {
        Task<PaginatedResponse<Product>> GetProductsAsync(int page, int pageSize);
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product?> UpdateProductAsync(int id, Product product);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<Product>> SearchProductsAsync(string query);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category);
    }
}
