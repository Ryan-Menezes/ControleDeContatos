using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Senha { get; set; } = string.Empty;
    }
}
