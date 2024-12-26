using ControleDeContatos.Enum;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [EmailAddress(ErrorMessage = "Esse e-mail é inválido")]
        public string Email { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public PerfilEnum Perfil { get; set; }

        public DateTime? DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}
