using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }
        public long CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public double Valor { get; set; }

        public string Imagem { get; set; }
    }
}
