using FrgStore.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    public class LoginController : BaseController
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
