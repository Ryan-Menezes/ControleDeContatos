using ControleDeContatos.Filters;
using ControleDeContatos.Models;
using ControleDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IContatoRepository _contatoRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository, IContatoRepository contatoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _contatoRepository = contatoRepository;
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

        public IActionResult ListarContatosPorUsuarioId(int id)
        {
            var contatos = _contatoRepository.BuscarTodos(id);

            return PartialView("_ContatosUsuario", contatos);
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

            var usuarioSemSenha = new UsuarioSemSenhaModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Login = usuario.Login,
                Email = usuario.Email,
                Perfil = usuario.Perfil,
            };

            return View(usuarioSemSenha);
        }

        [HttpPost]
        public IActionResult Alterar([FromForm] UsuarioSemSenhaModel usuarioSemSenha)
        {
            try
            {
                if (!ModelState.IsValid) return View("Editar", usuarioSemSenha);

                var usuario = new UsuarioModel
                {
                    Id = usuarioSemSenha.Id,
                    Nome = usuarioSemSenha.Nome,
                    Login = usuarioSemSenha.Login,
                    Email = usuarioSemSenha.Email,
                    Perfil = usuarioSemSenha.Perfil,
                };

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
