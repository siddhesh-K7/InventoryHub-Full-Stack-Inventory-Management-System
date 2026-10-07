using System.ComponentModel.DataAnnotations;

namespace InventoryHub.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required] public string Category { get; set; } = string.Empty;
        [Range(0.01, double.MaxValue)] public decimal Price { get; set; }
        [Range(0, int.MaxValue)] public int Quantity { get; set; }
        [Required] public string Supplier { get; set; } = string.Empty;
        [Required] public string SKU { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
