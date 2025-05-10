using BuyWise.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuyWise.Controllers
{
    public class CustomerController : Controller
    {

        BuyWiseDBContext _dbContext = new();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            _dbContext.Add(customer);
            _dbContext.SaveChanges();

            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {

            // Check equal false
            if (false)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


    }
}
