namespace FrgStore.Models
{

    public class ProdutoDTO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public double valor { get; set; }
        public string imagem { get; set; }
        public long categoriaId { get; set; }
    }
}
