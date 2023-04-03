using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Admin()
        {
            ViewBag.Title = "Admin";
            return View();
        }
    }
}
