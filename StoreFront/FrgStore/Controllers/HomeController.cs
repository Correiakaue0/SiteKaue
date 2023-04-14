using System.Diagnostics;
using FrgStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Store.Models;

namespace Store.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Carrossel()
        {
            ViewBag.Title = "Home";
            Response.Redirect("");
            return View();
        }
        //DAQUI PRA BAIXO NAO IMPORTA

        public void index()
        {
            Response.Redirect("Index.php");
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
