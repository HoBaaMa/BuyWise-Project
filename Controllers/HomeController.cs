using BuyWise.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BuyWise.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        BuyWiseDBContext _dbContext = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //HttpContext.Session.SetInt32("_ProductInCard", 0);


            var hotDeals = _dbContext.Products
                .Select(p => new
                {
                    ProductName = p.Name,
                    ProductId = p.Id,
                    ProductPrice = p.CurrentPrice,
                    ProductPriceAfterDiscount = p.CurrentPrice * (decimal)0.8,
                    ProductCategory = p.Category!.Name,
                    ProductBrand = p.Brand!.Name,
                    ProductImage = p.ProductImages!.FirstOrDefault()!.ImageUrl,
                    Discount = 20 // Example static discount, replace with real logic if needed
                })
                .Take(10)
                .ToList();
            ViewBag.HotDeals = hotDeals;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ProductSearch(long? categoryId, decimal? minPrice, decimal? maxPrice, string? txtSearch)
        {
            var result = _dbContext.Products.Where(p =>
                 (
                txtSearch == null
                ||
                (p.Name + p.Category.Name + p.Brand.Name).Contains(txtSearch))
                 &&
                (p.CategoryId == categoryId || categoryId == null) &&
                (minPrice == null || p.CurrentPrice >= minPrice) &&
                (maxPrice == null || p.CurrentPrice >= maxPrice)
             ).Select(p => new
             {
                 ProductName = p.Name,
                 ProductId = p.Id,
                 ProductPrice = p.CurrentPrice,
                 ProductPriceAfterDiscount = p.CurrentPrice * (decimal)0.8,
                 ProductCategory = p.Category!.Name,
                 ProductBrand = p.Brand!.Name,
                 ProductImage = p.ProductImages!.FirstOrDefault()!.ImageUrl,
             }).ToList();


            return View("ProductSearchResult", result);
        }

        public IActionResult ProductDetail(long productId)
        {

            var productDetail = _dbContext.Products.Where(p => p.Id == productId).Select(p => new
            {
                ProductName = p.Name,
                ProductShortDescription = p.ShortDescription,
                ProductDescription = p.Description,
                ProductId = p.Id,
                ProductPrice = p.CurrentPrice,
                ProductPriceAfterDiscount = p.CurrentPrice * (decimal)0.8,
                ProductCategory = p.Category!.Name,
                ProductBrand = p.Brand!.Name,
                ProductImages = p.ProductImages!.ToList(),
            }).FirstOrDefault();



            return View("Detail", productDetail);
        }



    }
}