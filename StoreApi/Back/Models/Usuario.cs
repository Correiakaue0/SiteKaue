using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "A Senha deve ter 8 caracteres")]
        public string Senha { get; set; }
    }
}
