using Back.Controllers;
using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using System.Collections.Generic;
using System.Linq;

namespace Back.Services
{
    public class UsuarioServices : IBaseController<Usuario>
    {
        private Context _context;

        public UsuarioServices(Context context)
        {
            _context = context;
        }

        public Usuario Create(Usuario user)
        {
            if (user == null) return null;

            Usuario usuario = new Usuario();
            usuario.Id = user.Id;
            usuario.Nome = user.Nome;
            usuario.Email = user.Email;
            usuario.Senha = user.Senha;
            _context.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public bool Delete(int id)
        {
            Usuario usuario = _context.Usuario.FirstOrDefault(x => x.Id == id);
            if (usuario != null)
            {
                _context.Remove(usuario);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Usuario Edit(int id, Usuario New)
        {
            Usuario produto = _context.Usuario.FirstOrDefault(x => x.Id == id);
            if (produto != null)
            {
                produto.Nome = New.Nome;
                produto.Email = New.Email;
                produto.Senha = New.Senha;
                _context.SaveChanges();
                return produto;
            }
            return null;
        }

        public List<Usuario> Get()
        {
            List<Usuario> usuario = _context.Usuario.ToList();
            if (usuario != null) return usuario;
            return null;
        }

        public Usuario GetForId(int id)
        {
            Usuario usuario = _context.Usuario.FirstOrDefault(u => u.Id == id);
            if(usuario != null) return usuario;
            return null;
        }
        public Usuario Login(string email, string senha)
        {
            Usuario usuario = _context.Usuario.FirstOrDefault(u => u.Email == email);
            if (usuario == null)
                throw new System.ArgumentException("Usuario não existe !");
            if (usuario.Senha != senha)
                throw new System.ArgumentException("Senha incorreta !");

            return usuario;
        }
    }
}
