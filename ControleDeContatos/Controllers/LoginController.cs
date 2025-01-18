using ControleDeContatos.Helpers;
using ControleDeContatos.Models;
using ControleDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepository usuarioRepository, ISessao sessao)
        {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            var sessao = _sessao.BuscarSessaoDoUsuario();

            if (sessao != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar([FromForm] LoginModel loginModel)
        {
            try
            {
                if (!ModelState.IsValid) return View("Index");

                var usuario = _usuarioRepository.BuscarPorLogin(loginModel.Login);

                if (usuario == null || !usuario.SenhaValida(loginModel.Senha))
                {
                    TempData["erro"] = "Login ou senha inválidos!";
                    return View("Index");
                }

                _sessao.CriarSessaoDoUsuario(usuario);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["erro"] = $"Ops! não consegimos realizar seu login, tente novamente, Erro: {ex.Message}";

                return RedirectToAction("Index");
            }
        }
    }
}
