using ControleDeContatos.Filters;
using ControleDeContatos.Helpers;
using ControleDeContatos.Models;
using ControleDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly ISessao _sessao;

        public ContatoController(IContatoRepository contatoRepository, ISessao sessao)
        {
            _contatoRepository = contatoRepository;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            var usuario = _sessao.BuscarSessaoDoUsuario();
            var contatos = _contatoRepository.BuscarTodos(usuario.Id);

            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar([FromForm] ContatoModel contato)
        {
            try
            {
                if (!ModelState.IsValid) return View(contato);

                var usuario = _sessao.BuscarSessaoDoUsuario();

                contato.UsuarioId = usuario?.Id;

                _contatoRepository.Adicionar(contato);

                TempData["sucesso"] = "Contato cadastrado com sucesso";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["erro"] = $"Ops! não consegimos cadastrar seu contato, tente novamente, Erro: {ex.Message}";

                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int id)
        {
            var contato = _contatoRepository.BuscarPorId(id);

            return View(contato);
        }

        [HttpPost]
        public IActionResult Alterar([FromForm] ContatoModel contato)
        {
            try
            {
                if (!ModelState.IsValid) return View("Editar", contato);

                var usuario = _sessao.BuscarSessaoDoUsuario();

                contato.UsuarioId = usuario?.Id;

                _contatoRepository.Atualizar(contato);

                TempData["sucesso"] = "Contato atualizado com sucesso";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["erro"] = $"Ops! não consegimos atualizar seu contato, tente novamente, Erro: {ex.Message}";

                return RedirectToAction("Index");
            }
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            var contato = _contatoRepository.BuscarPorId(id);

            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepository.Apagar(id);

                if (apagado)
                {
                    TempData["sucesso"] = "Contato deletado com sucesso";
                }
                else
                {
                    TempData["erro"] = "Ops! não consegimos deletar seu contato, tente novamente";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["erro"] = $"Ops! não consegimos deletar seu contato, tente novamente, Erro: {ex.Message}";

                return RedirectToAction("Index");
            }
        }
    }
}
