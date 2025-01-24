using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [EmailAddress(ErrorMessage = "Esse e-mail é inválido")]
        public string Email { get; set; } = string.Empty;
    }
}
