using ControleDeContatos.Models;

namespace ControleDeContatos.Repositories
{
    public interface IUsuarioRepository
    {
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel BuscarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel contato);
        UsuarioModel Atualizar(UsuarioModel contato);
        bool Apagar(int id);
    }
}
