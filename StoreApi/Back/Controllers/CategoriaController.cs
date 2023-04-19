using Back.Models;
using Back.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private CategoriaServices _categoriaServices;

        public CategoriaController(CategoriaServices categoriaServices)
        {
            _categoriaServices = categoriaServices;
        }

        [HttpPost("create")]
        public Categoria Create([FromBody] Categoria cat)
        {
            var categoria = _categoriaServices.Create(cat);
            return categoria;
        }

        [HttpGet]
        public List<Categoria> Get()
        {
            var categoria = _categoriaServices.Get();
            return categoria;

        }
    }
}
