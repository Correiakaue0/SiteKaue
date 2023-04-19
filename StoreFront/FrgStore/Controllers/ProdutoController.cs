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

        public CategoriaCadastradoViewModel CadastraCategoria(CategoriaDTO categoria)
        {
            RestResponse retorno = ExecutaApi("/Categoria/create", Method.Post, categoria);
            var retornoCategoria = JsonSerializer.Deserialize<CategoriaDTO>(retorno.Content);
            var ret = new CategoriaCadastradoViewModel()
            {
                Content = retorno.Content,
                ErrorException = retorno.ErrorException,
                ErrorMessage = retorno.ErrorMessage,
                ResponseStatus = retorno.ResponseStatus,
                StatusCode = retorno.StatusCode,
                categoriaId = retornoCategoria.categoriaId,
                codigo = retornoCategoria.codigo,
                descricao = retornoCategoria.descricao,
            };
            return ret;
        }
        public RetornoAPIViewModel DeleteProduto(ProdutoDTO produto)
        {
            RestResponse retorno = ExecutaApi("/Produto/", Method.Delete, produto.id);
            var retornoProduto = JsonSerializer.Deserialize<ProdutoDTO>(retorno.Content);

            try
            {
                var path = _enviroment.ContentRootPath + @"\wwwroot\imagensProduto\" + retornoProduto.imagem;
                string[] files = Directory.GetFiles(_enviroment.ContentRootPath + @"\wwwroot\imagensProduto\", retornoProduto.imagem);
                System.IO.File.Delete(files[0]);
            }
            catch (Exception ex) { }

            var ret = new RetornoAPIViewModel()
            {
                Content = retorno.Content,
                ErrorException = retorno.ErrorException,
                ErrorMessage = retorno.ErrorMessage,
                ResponseStatus = retorno.ResponseStatus,
                StatusCode = retorno.StatusCode
            };
            return ret;
        }

        public IActionResult CadastrarProduto(ProdutoDTO produto, IFormFile file)
        {

            var imagemName = file.FileName;
            var patch = Path.Combine(_enviroment.ContentRootPath, @"wwwroot\imagensProduto", imagemName);
            
            if (System.IO.File.Exists(patch))
            {
                imagemName = Guid.NewGuid().ToString() + file.FileName;
                patch = Path.Combine(_enviroment.ContentRootPath, @"wwwroot\imagensProduto", imagemName);
            }
            produto.imagem = imagemName;
            ValidarCampos(produto);
            var fileStream = new FileStream(patch, FileMode.Create);
            
            file.CopyTo(fileStream);
            fileStream.Dispose();

            RestResponse retorno = ExecutaApi("/Produto/create", Method.Post, produto);

            var ret = new RetornoAPIViewModel()
            {
                Content = retorno.Content,
                ErrorException = retorno.ErrorException,
                ErrorMessage = retorno.ErrorMessage,
                ResponseStatus = retorno.ResponseStatus,
                StatusCode = retorno.StatusCode
            };

            if (retorno.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var retornoProduto = JsonSerializer.Deserialize<ProdutoDTO>(retorno.Content);
                ret.Produto = new ProdutoViewModel
                {
                    id = retornoProduto.id,
                    nome = retornoProduto.nome,
                    descricao = retornoProduto.descricao,
                    imagem = retornoProduto.imagem,
                    valor = retornoProduto.valor
                };
                return RedirectToRoute(new { controller = "Home", action = "Carrossel" });
            }
            return RedirectToRoute(new { controller = "Produto", action = "CadastroProduto" });
        }

        private void ValidarCampos(ProdutoDTO produto)
        {
            if (produto.nome == null)
                throw new Exception();

            if (produto.descricao == null)
                throw new Exception();

            if (produto.imagem == null)
                throw new Exception();

            if (produto.valor == 0)
                throw new Exception();

            if (produto.categoriaId == 0)
                throw new Exception();
        }
    }
}
