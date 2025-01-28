using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class AlterarSenhaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string NovaSenha { get; set; } = string.Empty;

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Compare("NovaSenha", ErrorMessage = "A senha não confere com a nova senha")]
        public string ConfirmarNovaSenha { get; set; } = string.Empty;
    }
}
