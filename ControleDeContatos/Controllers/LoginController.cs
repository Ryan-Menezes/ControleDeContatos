using ControleDeContatos.Models;
using ControleDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            return View();
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
