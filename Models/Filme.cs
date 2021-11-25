using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo necessário")]
        [MaxLength(40, ErrorMessage = "Esse campo só permite até 40 caracteres")]
        [MinLength(3, ErrorMessage = "Nome muito pequeno, minimo 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo necessário")]
        [MaxLength(2000, ErrorMessage = "Esse campo só permite até 2000 caracteres")]
        [MinLength(5, ErrorMessage = "Descrição muito pequeno, minimo 5 caracteres")]
        public string Descricao { get; set; }
    }
}