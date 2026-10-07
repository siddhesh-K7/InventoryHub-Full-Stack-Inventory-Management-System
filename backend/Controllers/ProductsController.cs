using InventoryHub.Models;
using InventoryHub.DTOs;
using InventoryHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service) { _service = service; }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _service.GetProductsAsync(page, pageSize);
            return Ok(new ApiResponse<PaginatedResponse<Product>> { Success = true, Message = "Products retrieved successfully", Data = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null) return NotFound(new ApiResponse<Product> { Success = false, Message = "Product not found" });
            return Ok(new ApiResponse<Product> { Success = true, Message = "Product found", Data = product });
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var created = await _service.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = created.Id }, new ApiResponse<Product> { Success = true, Message = "Product created", Data = created });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            var updated = await _service.UpdateProductAsync(id, product);
            if (updated == null) return NotFound(new ApiResponse<Product> { Success = false, Message = "Product not found" });
            return Ok(new ApiResponse<Product> { Success = true, Message = "Product updated", Data = updated });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _service.DeleteProductAsync(id);
            if (!deleted) return NotFound(new ApiResponse<bool> { Success = false, Message = "Product not found" });
            return Ok(new ApiResponse<bool> { Success = true, Message = "Product deleted successfully" });
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts([FromQuery] string query)
        {
            var results = await _service.SearchProductsAsync(query);
            return Ok(new ApiResponse<IEnumerable<Product>> { Success = true, Message = "Search complete", Data = results });
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetByCategory(string category)
        {
            var results = await _service.GetProductsByCategoryAsync(category);
            return Ok(new ApiResponse<IEnumerable<Product>> { Success = true, Message = "Category retrieved", Data = results });
        }
    }
}
