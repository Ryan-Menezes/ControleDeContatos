using ControleDeContatos.Filters;
using ControleDeContatos.Helpers;
using ControleDeContatos.Models;
using ControleDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepository usuarioRepository, ISessao sessao)
        {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Alterar([FromForm] AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                if (!ModelState.IsValid) return View("Index", alterarSenhaModel);

                var sessao = _sessao.BuscarSessaoDoUsuario();

                if (sessao == null) return View("Index", alterarSenhaModel);

                alterarSenhaModel.Id = sessao.Id;
                _usuarioRepository.AlterarSenha(alterarSenhaModel);

                TempData["sucesso"] = "Senha alterada com sucesso!";

                return View("Index", alterarSenhaModel);
            } 
            catch (Exception ex)
            {
                TempData["erro"] = $"Ops! não consegimos alterar sua senha, tente novamente, Erro: {ex.Message}";

                return RedirectToAction("Index");
            }
        }
    }
}
