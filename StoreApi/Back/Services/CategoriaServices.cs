using Back.Models;
using Store.Data;
using System.Collections.Generic;
using System.Linq;

namespace Back.Services
{
    public class CategoriaServices
    {
        private Context _context;

        public CategoriaServices(Context context)
        {
            _context = context;
        }

        public Categoria Create(Categoria categoria)
        {
            if (categoria == null) return null;
            _context.Add(categoria);
            _context.SaveChanges();
            return categoria;
        }

        public List<Categoria> Get()
        {
            List<Categoria> categoria = _context.Categoria
                .Select(x => new Categoria
                {
                    CategoriaId = x.CategoriaId,
                    Codigo = x.Codigo,
                    Descricao = x.Descricao,
                }).ToList();
            return categoria;
        }
    }
}
