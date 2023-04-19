using FrgStore.Controllers;
using FrgStore.Models;
using FrgStore.Models.ProdutoCadastradoViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.IO;
using System.Text.Json;

namespace Store.Controllers
{
    public class ProdutoController : BaseController
    {
        public readonly IHostingEnvironment _enviroment;
        public ProdutoController(IHostingEnvironment environment)
        {
            _enviroment = environment;
        }

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
            var retornoProduto = JsonSerializer.Deserialize<ProdutoDTO>(retorno.Content);

            try
            {
                var path = _enviroment.ContentRootPath + @"\wwwroot\imagensProduto\" + retornoProduto.imagem;
                string[] files = Directory.GetFiles(_enviroment.ContentRootPath + @"\wwwroot\imagensProduto\", retornoProduto.imagem);
                System.IO.File.Delete(files[0]);
            }
            catch (Exception ex) { }

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

        public IActionResult CadastrarProduto(Produto produto, IFormFile file)
        {

            var imagemName = file.FileName;
            var patch = Path.Combine(_enviroment.ContentRootPath, @"wwwroot\imagensProduto", imagemName);
            
            if (System.IO.File.Exists(patch))
            {
                imagemName = Guid.NewGuid().ToString() + file.FileName;
                patch = Path.Combine(_enviroment.ContentRootPath, @"wwwroot\imagensProduto", imagemName);
            }
            produto.Imagem = imagemName;
            ValidarCampos(produto);
            var fileStream = new FileStream(patch, FileMode.Create);
            
            file.CopyTo(fileStream);
            fileStream.Dispose();

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
                return RedirectToRoute(new { controller = "Home", action = "Carrossel" });
            }
            return RedirectToRoute(new { controller = "Produto", action = "CadastroProduto" });
        }

        private void ValidarCampos(Produto produto)
        {
            if (produto.Nome == null)
                throw new Exception();

            if (produto.Descricao == null)
                throw new Exception();

            if (produto.Imagem == null)
                throw new Exception();

        }
    }
}
