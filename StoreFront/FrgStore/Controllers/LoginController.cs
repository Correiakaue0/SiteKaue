using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Login";
            return View();
        }
        public IActionResult Cadastro()
        {
            ViewBag.Title = "Cadastro";
            return View();
        }
    }
}
