using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatorio")]
        [MaxLength(40, ErrorMessage = "Maxímo permitido, 40 caracteres")]
        [MinLength(3, ErrorMessage = "Minimo necessario, 3 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "senha obrigatorio")]
        [MaxLength(20, ErrorMessage = "Maxímo permitido, 20 caracteres")]
        [MinLength(3, ErrorMessage = "Minimo necessario, 3 caracteres")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}