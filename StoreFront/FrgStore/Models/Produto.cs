namespace FrgStore.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public string Imagem { get; set; }
    }

    public class ProdutoDTO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public double valor { get; set; }
        public string imagem { get; set; }
    }
}
