using ControleDeContatos.Models;

namespace ControleDeContatos.Helpers
{
    public interface ISessao
    {
        UsuarioModel? BuscarSessaoDoUsuario();
        void CriarSessaoDoUsuario(UsuarioModel usuarioModel);
        void RemoverSessaoDoUsuario();
    }
}
