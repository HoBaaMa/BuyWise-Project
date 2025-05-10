namespace BuyWise.Models.Products
{
    public class Brand : BaseModel
    {
        public string? ImageUrl { get; set; }
        public List<Product>? Products { get; set; }
    }
}
