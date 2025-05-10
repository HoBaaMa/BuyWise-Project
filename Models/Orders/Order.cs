using BuyWise.Models.StaticEntities;

namespace BuyWise.Models.Orders
{
    public class Order : BaseModel
    {
        public DateTime OrderDate { get; set; }
        public long CustomerId { get; set; }
        public string RefrenceNumber { get; set; }
        public long OrderStatusId { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
