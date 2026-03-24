using Microsoft.AspNetCore.Mvc;
using SsoBarbearia.Aplicacao.Interfaces;

namespace SsoBarbearia.Controllers
{
    public class SsoController(ISsoApp app) : ControllerBase
    {
        private readonly ISsoApp _app = app;

        [HttpGet("verificar-dominio")]
        public IActionResult VerificarDominio([FromQuery] string dominio)
        {
            var autorizado = _app.VerificarDominio(dominio);
            return Ok(new { autorizado });
        }
    }
}
