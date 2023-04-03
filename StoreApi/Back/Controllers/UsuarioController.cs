using Back.Models;
using Back.Services;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase, IBaseController<Usuario>
    {
        private UsuarioServices _userServices;

        public UsuarioController(UsuarioServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        public Usuario Create(Usuario user)
        {
            var usuario = _userServices.Create(user);
            return usuario;
        }

        [HttpGet]
        public List<Usuario> Get()
        {
            var getUser = _userServices.Get();
            return getUser;

        }

        [HttpGet("{id}")]
        public Usuario GetForId(int id)
        {
            Usuario usuario = _userServices.GetForId(id);
            return usuario;

        }

        [HttpGet("login")]
        public IActionResult Login(string email, string senha)
        {
            try
            {
                return Ok(_userServices.Login(email, senha));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public Usuario Edit(int id, Usuario NewUser)
        {
            var edit = _userServices.Edit(id, NewUser);
            return edit;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            var delete = _userServices.Delete(id);
            return delete;
        }

    }
}
