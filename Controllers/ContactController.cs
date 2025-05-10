using Microsoft.AspNetCore.Mvc;

namespace BuyWise.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Contact For Any Questions";
            ViewData["Address1"] = "123 Street, New York, USA";
            ViewData["Email1"] = "info@gitspro.online";
            return View();
        }
    }
}
