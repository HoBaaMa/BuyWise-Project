using BuyWise.Models.Products;

namespace BuyWise.Models.Orders
{
    public class OrderDetail
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public Product? product { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public int Qty { get; set; }
        public decimal ItemPrice { get; set; } = decimal.Zero;
        public decimal ItemPriceAfterDiscount { get; set; } = decimal.Zero;
    }
}
