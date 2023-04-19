namespace Back.ViewModel
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }
        public long CategoriaId { get; set; }

        public double Valor { get; set; }

        public string Imagem { get; set; }
    }
}
