using ControleDeContatos.Models;
using Newtonsoft.Json;

namespace ControleDeContatos.Helpers
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;
        private const string KEY = "sessaoUsuarioLogado";

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public UsuarioModel? BuscarSessaoDoUsuario()
        {
            var sessaoUsuario = _httpContext?.HttpContext?.Session.GetString(KEY);

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(UsuarioModel usuarioModel)
        {
            string valor = JsonConvert.SerializeObject(usuarioModel);

            _httpContext?.HttpContext?.Session.SetString(KEY, valor);
        }

        public void RemoverSessaoDoUsuario()
        {
            _httpContext?.HttpContext?.Session.Remove(KEY);
        }
    }
}
