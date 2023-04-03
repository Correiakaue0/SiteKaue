using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Models
{
    [Table("Usuario")]    // => nome da Tabela 
    public class Usuario
    {
        [Display(Name = "Codigo")]
        [Column("Id")] // => nome da Coluna
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Column("Nome")] 
        public string Nome { get; set; }
    }
}
