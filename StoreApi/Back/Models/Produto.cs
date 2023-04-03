using System.ComponentModel.DataAnnotations;

namespace Store.Model
{
    public class Produto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do Produto Obrigatorio!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição Obrigatoria!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Valor Obrigatorio!")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio !")]
        public string Imagem { get; set; }
    }
}
