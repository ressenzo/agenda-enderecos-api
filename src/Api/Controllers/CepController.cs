using System.Threading.Tasks;
using Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : BaseController
    {
        private readonly ICepRepositorio _cepRepositorio;

        public CepController(ICepRepositorio cepRepositorio)
        {
            _cepRepositorio = cepRepositorio;
        }

        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> ObterCepsPorUsuario(string idUsuario)
        {
            var ceps = await _cepRepositorio.ObterCepsPorUsuario(idUsuario);

            return RetornarListaOk(ceps);
        }
    }
}
