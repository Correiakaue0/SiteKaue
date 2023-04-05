using FrgStore.Models;
using FrgStore.Models.ProdutoCadastradoViewModel;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

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
        public ProdutoCadastradoViewModel CadastrarProduto(Produto produto)
        {
            var client = new RestClient("https://localhost:5001");

            var request = new RestRequest($@"/Produto/create", Method.Post)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(produto);

            RestResponse retorno = client.Execute(request);

            var ret = new ProdutoCadastradoViewModel()
            {
                Content = retorno.Content,
                ErrorException = retorno.ErrorException,
                ErrorMessage = retorno.ErrorMessage,
                ResponseStatus = retorno.ResponseStatus,
                StatusCode = retorno.StatusCode
            };

            if (retorno.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var retornoProduto = JsonSerializer.Deserialize<Produto>(retorno.Content);
                ret.Produto = new ProdutoViewModel
                {
                    id = retornoProduto.Id,
                    nome = retornoProduto.Nome,
                    descricao = retornoProduto.Descricao,
                    imagem = retornoProduto.Imagem,
                    valor = retornoProduto.Valor
                };
                return ret;
            }
            return ret;
        }
    }
}
