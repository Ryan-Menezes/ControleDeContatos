using ControleDeContatos.Models;

namespace ControleDeContatos.Repositories
{
    public interface IContatoRepository
    {
        ContatoModel BuscarPorId(int id);
        List<ContatoModel> BuscarTodos(int usuarioId);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}
