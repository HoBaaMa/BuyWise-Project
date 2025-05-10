using BuyWise.Models;
using BuyWise.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BuyWise.Controllers
{
    public class DashboardController : Controller
    {

        BuyWiseDBContext _dbContext = new();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayCustomers()
        {
            var customers = _dbContext.Customers.ToList();
            return View(customers);
        }

        public IActionResult EditCustomerDetails(long? customerId)
        {
            if (customerId != null)
            {
                //var customer = _dbContext.Customers.Where(c => c.Id == customerId);
                //Second approach since we only search by id
                var customer = _dbContext.Customers.Find(customerId);
                return View(customer);
            }
            return RedirectToAction("DisplayCustomers");
        }

        [HttpPost]
        public IActionResult EditCustomerDetails(Customer customer)
        {
            var updatedCustomer = _dbContext.Customers.Find(customer.Id);
            updatedCustomer.Name = customer.Name;
            updatedCustomer.Email = customer.Email;
            updatedCustomer.Mobile = customer.Mobile;
            updatedCustomer.LastModifiedDate = DateTime.Now;
            _dbContext.SaveChanges();
            return View(updatedCustomer);
        }

        public IActionResult DeleteCustomer(long? customerId)
        {
            var customer = _dbContext.Customers.Find(customerId);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("DisplayCustomers");
        }

        public IActionResult DisplayCategories()
        {
            //var categories = from c in _dbContext.Categories
            //                 select c;
            var categories = _dbContext.Categories.ToList();

            return View(categories);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category newCategory)
        {
            _dbContext.Categories.Add(newCategory);
            _dbContext.SaveChanges();
            return View();
        }

        public IActionResult EditCategoryDetails(long? categoryId)
        {
            if (categoryId != null)
            {
                var category = _dbContext.Categories.Find(categoryId);
                return View(category);
            }
            return RedirectToAction("DisplayCategories");
        }

        [HttpPost] 
        public IActionResult EditCategoryDetails(Category category)
        {
            var updatedCategory = _dbContext.Categories.Find(category.Id);
            updatedCategory.Name = category.Name;
            updatedCategory.Description = category.Description;
            updatedCategory.ImageURL = category.ImageURL;
            category.LastModifiedDate = DateTime.Now;
            _dbContext.SaveChanges();
            return View(updatedCategory);
        }

    }
}
