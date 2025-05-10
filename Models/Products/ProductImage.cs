using System.ComponentModel.DataAnnotations;

namespace BuyWise.Models.Products
{
    public class ProductImage
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "*")]
        public required string ImageUrl { get; set; }
        public long ProductId { get; set; }
        public Product? Product { get; set; }
        public bool? IsDefault { get; set; } = false;

    }
}
