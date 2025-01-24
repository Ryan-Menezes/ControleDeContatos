using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.ViewComponents
{
    public class Mensagens : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
