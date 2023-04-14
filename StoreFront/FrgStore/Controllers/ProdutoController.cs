using FrgStore.Controllers;
using FrgStore.Models;
using FrgStore.Models.ProdutoCadastradoViewModel;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

namespace Store.Controllers
{
    public class ProdutoController : BaseController
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
        public ProdutoCadastradoViewModel DeleteProduto(Produto produto)
        {
            RestResponse retorno = ExecutaApi("/Produto/", Method.Delete, produto.Id);
            var ret = new ProdutoCadastradoViewModel()
            {
                Content = retorno.Content,
                ErrorException = retorno.ErrorException,
                ErrorMessage = retorno.ErrorMessage,
                ResponseStatus = retorno.ResponseStatus,
                StatusCode = retorno.StatusCode
            };
            return ret;
        }

        public ProdutoCadastradoViewModel CadastrarProduto(Produto produto)
        {

            RestResponse retorno = ExecutaApi("/Produto/create", Method.Post, produto);

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
