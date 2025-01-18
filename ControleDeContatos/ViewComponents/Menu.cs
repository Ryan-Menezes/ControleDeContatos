using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ControleDeContatos.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sessaoUsuario = HttpContext?.Session?.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrWhiteSpace(sessaoUsuario)) return null;

            var usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

            return View(usuario);
        }
    }
}
