using ControleDeContatos.Models;
using ControleDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            var usuarios = _usuarioRepository.BuscarTodos();

            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar([FromForm] UsuarioModel usuario)
        {
            try
            {
                if (!ModelState.IsValid) return View(usuario);

                _usuarioRepository.Adicionar(usuario);

                TempData["sucesso"] = "Usuário cadastrado com sucesso";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["erro"] = $"Ops! não consegimos cadastrar seu usuário, tente novamente, Erro: {ex.Message}";

                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int id)
        {
            var usuario = _usuarioRepository.BuscarPorId(id);

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Alterar([FromForm] UsuarioModel usuario)
        {
            try
            {
                if (!ModelState.IsValid) return View("Editar", usuario);

                _usuarioRepository.Atualizar(usuario);

                TempData["sucesso"] = "Usuário atualizado com sucesso";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["erro"] = $"Ops! não consegimos atualizar seu usuário, tente novamente, Erro: {ex.Message}";

                return RedirectToAction("Index");
            }
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            var usuario = _usuarioRepository.BuscarPorId(id);

            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepository.Apagar(id);

                if (apagado)
                {
                    TempData["sucesso"] = "Usuário deletado com sucesso";
                }
                else
                {
                    TempData["erro"] = "Ops! não consegimos deletar seu usuário, tente novamente";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["erro"] = $"Ops! não consegimos deletar seu usuário, tente novamente, Erro: {ex.Message}";

                return RedirectToAction("Index");
            }
        }
    }
}
