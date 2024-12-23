using ControleDeContatos.Models;
using ControleDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public IActionResult Index()
        {
            var contatos = _contatoRepository.BuscarTodos();

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

                _contatoRepository.Adicionar(contato);

                TempData["sucesso"] = "Contato cadastrado com sucesso";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["erro"] = $"Ops! não consegimos cadastrar seu contatos, tente novamente, Erro: {ex.Message}";

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
