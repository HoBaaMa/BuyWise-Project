using System.ComponentModel.DataAnnotations;

namespace BuyWise.Models.Products
{
    //public record ProductStock(long productId, float Qty);

    public class Product : BaseModel
    {

        public string? ShortDescription { get; set; }
        public string? ArabicName { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "*")]
        public required decimal CurrentPrice { get; set; }
        public long CategoryId { get; set; }
        public Category? Category { get; set; }
        public long BrandId { get; set; }
        public Brand? Brand { get; set; }
        public IEnumerable<ProductImage>? ProductImages { get; set; }
        //public long Rate { get; set; }

        //public List<ProductStock>? ProductStocks { get; set; }

    }









}
