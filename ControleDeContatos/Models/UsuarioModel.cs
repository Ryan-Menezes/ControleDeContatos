using ControleDeContatos.Enum;
using ControleDeContatos.Helpers;
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

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public PerfilEnum? Perfil { get; set; }

        public DateTime? DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public virtual List<ContatoModel> Contatos { get; set; } = new List<ContatoModel>();

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public void SetNovaSenha(string senha)
        {
            Senha = senha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string senha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = senha.GerarHash();
            return senha;
        }
    }
}
