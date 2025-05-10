namespace BuyWise.Models.Products
{
    public class Category : BaseModel
    {
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public List<Product>? Products { get; set; }

    }
}
