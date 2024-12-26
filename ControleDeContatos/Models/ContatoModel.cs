using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [EmailAddress(ErrorMessage = "Esse e-mail é inválido")]
        public string Email { get; set;} = string.Empty;

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Phone(ErrorMessage = "Esse celular é inválido")]
        public string Celular { get; set; } = string.Empty;
    }
}
