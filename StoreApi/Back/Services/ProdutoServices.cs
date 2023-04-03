using Back.Controllers;
using Store.Data;
using Store.Model;
using System.Collections.Generic;
using System.Linq;

namespace Back.Services
{
    public class ProdutoServices : IBaseController<Produto>
    {
        private Context _context;

        public ProdutoServices(Context context)
        {
            _context = context;
        }

        public Produto Create(Produto prod)
        {
            if (prod == null) return null;
            Produto produto = new Produto();
            produto.Id = produto.Id;
            produto.Nome = prod.Nome;
            produto.Descricao = prod.Descricao;
            produto.Imagem = prod.Imagem;
            produto.Valor = prod.Valor;
            _context.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public bool Delete(int id)
        {
            Produto produto = _context.Produto.FirstOrDefault(x => x.Id == id);
            if (produto != null)
            {
                _context.Remove(produto);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Produto Edit(int id, Produto New)
        {
            Produto produto = _context.Produto.FirstOrDefault(x => x.Id == id);
            if (produto != null)
            {
                produto.Nome = New.Nome;
                produto.Descricao = New.Descricao;
                produto.Imagem= New.Imagem;
                produto.Valor = New.Valor;
                _context.SaveChanges();
                return produto;
            }
            return null;
        }

        public List<Produto> Get()
        {
            List<Produto> produto = _context.Produto.ToList();
            return produto;
        }

        public Produto GetForId(int id)
        {
            Produto produto = _context.Produto.FirstOrDefault(p => p.Id == id);
            if (produto == null) return null;
            return produto;
        }
    }
}
