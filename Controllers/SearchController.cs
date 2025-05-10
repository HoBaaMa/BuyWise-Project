using Microsoft.AspNetCore.Mvc;
using BuyWise.Models;

namespace BuyWise.Controllers
{
    public class SearchFilterItems
    {
        public string? ProductName { get; set; }
        public decimal? MinimumPrice { get; set; }
        public decimal? MaximumPrice { get; set; }
        public long? CategoryId { get; set; }
        public long? BrandId { get; set; }
        public string? SearchFor { get; set; }
    }

    public class SearchController : Controller
    {
        BuyWiseDBContext _dbContext;
        public SearchController()
        {
            _dbContext = new();
        }
        public IActionResult Index(SearchFilterItems searchFilterItems)
        {

            var result = _dbContext.Products
                    .Where(p =>
                            (searchFilterItems.ProductName == null || p.Name == searchFilterItems.ProductName)
                            &&
                            (
                            (searchFilterItems.MinimumPrice == null || p.CurrentPrice >= searchFilterItems.MinimumPrice)
                            &&
                            (searchFilterItems.MaximumPrice == null || p.CurrentPrice <= searchFilterItems.MaximumPrice)
                            )
                            &&
                            (searchFilterItems.CategoryId == null || p.CategoryId == searchFilterItems.CategoryId)
                            &&
                            (searchFilterItems.BrandId == null || p.BrandId == searchFilterItems.BrandId)
                            &&
                            (searchFilterItems.SearchFor == null
                            || (p.Name + p.Category.Name + p.Brand.Name + p.Description + p.ShortDescription + p.Category.Description).Contains(searchFilterItems.SearchFor))
                    )
                    .Select(p => new
                    {
                        ProductId = p.Id,
                        ProductName = p.Name,
                        ProductShortDescription = p.ShortDescription,
                        ProductPrice = p.CurrentPrice,
                        ProductPriceAfterDiscount = p.CurrentPrice * (decimal)0.65,
                        ProductDescription = p.Description,
                        ProductCategoryId = p.CategoryId,
                        ProductCategoryName = p.Category!.Name,
                        ProductBrandId = p.BrandId,
                        ProductBrand = p.Brand!.Name,
                        ProductImage = p.ProductImages!.FirstOrDefault(i => i.IsDefault == true)!.ImageUrl,
                    }
                ).OrderByDescending(p => p.ProductId).ToList();


            return View(result);
        }
    }
}
