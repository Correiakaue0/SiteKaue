using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult CadastroProduto()
        {
            ViewBag.Title = "Produto";
            return View();
        }
        public IActionResult Detalhes()
        {
            ViewBag.Title = "Produto";
            return View();
        }
    }
}
