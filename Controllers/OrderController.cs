using Microsoft.AspNetCore.Mvc;
using BuyWise.Models.Orders;
using BuyWise.Models;

namespace BuyWise.Controllers
{

    public class CardDetail
    {
        public long ProductId { get; set; }
        public int Qty { get; set; } = 1;
        public decimal ProductPrice { get; set; }
        public decimal ProductPriceAfterDiscount { get; set; }
    }
    public class OrderController : Controller
    {

        BuyWiseDBContext _dbContext;
        public OrderController()
        {
            _dbContext = new();
        }

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult AddToCart(CardDetail cardDetail)
        {
            Order order = new()
            {
                Name = "",
                OrderDate = DateTime.Now,
                CustomerId = 2,
                OrderStatusId = 1,
                RefrenceNumber = "123456789",
                 
            };
                _dbContext.Orders.Add(order);


            order.OrderDetails.Add(new OrderDetail()
            {
                OrderId = 0,
                ProductId = cardDetail.ProductId,
                Qty = cardDetail.Qty,
                ItemPrice = cardDetail.ProductPrice,
                ItemPriceAfterDiscount = cardDetail.ProductPriceAfterDiscount,

            });
            

            return View();
        }
    }
}
