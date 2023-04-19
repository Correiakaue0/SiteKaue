using Back.Services;
using Back.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Model;
using System.Collections.Generic;
using System.Linq;

namespace Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private ProdutoServices _prodServices;

        public ProdutoController(ProdutoServices prodServices)
        {
            _prodServices = prodServices;
        }

        [HttpPost("create")]
        public Produto Create([FromBody] ProdutoViewModel prod)
        {
            var produto = _prodServices.Create(prod);
            return produto;
        }

        [HttpGet]
        public List<Produto> Get()
        {
            var produto = _prodServices.Get();
            return produto;

        }

        [HttpGet("{id}")]
        public Produto GetForId(int id)
        {
            var get = _prodServices.GetForId(id); 
            return get;

        }

        [HttpPut]
        public Produto Edit(int id, Produto produtoNovo)
        {
            var edit = _prodServices.Edit(id, produtoNovo); 
            return edit;
        }

        [HttpDelete]
        public Produto Delete([FromBody] int id)
        {
            var del = _prodServices.Delete(id);
            return del;
        }
    }
}
