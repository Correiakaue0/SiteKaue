using RestSharp;
using System;
using System.Net;

namespace FrgStore.Models.ProdutoCadastradoViewModel
{
    public class ProdutoCadastradoViewModel
    {
        public string Content { get; internal set; }
        public Exception ErrorException { get; internal set; }
        public string ErrorMessage { get; internal set; }
        public ResponseStatus ResponseStatus { get; internal set; }
        public HttpStatusCode StatusCode { get; internal set; }
        public ProdutoViewModel Produto { get; internal set; }
    }

    public class ProdutoViewModel
    {
        public long id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string imagem { get; set; }
        public double valor { get; set; }
    }
}
