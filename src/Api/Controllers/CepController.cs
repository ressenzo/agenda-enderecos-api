using System.Threading.Tasks;
using Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using Dominio.Entidades;
using Api.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : BaseController
    {
        private readonly ICepRepositorio _cepRepositorio;
        private readonly IMapper _mapper;

        public CepController(ICepRepositorio cepRepositorio,
            IMapper mapper
        )
        {
            _cepRepositorio = cepRepositorio;
            _mapper = mapper;
        }

        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> ObterCepsPorUsuario(string idUsuario)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(idUsuario))
                {
                    var erros = new List<string>()
                    {
                        "IdUsuario inválido"
                    };

                    return RetornarBadRequest(erros);
                }

                var ceps = await _cepRepositorio.ObterCepsPorUsuario(idUsuario);

                if (ceps == null || ceps.Count() == 0)
                {
                    return NoContent();
                }

                return RetornarCepsPorUsuario(ceps);
            }
            catch
            {
                // LogarErro(excecao.Message);
                return RetornarErroInterno("Ocorreu um erro interno ao obter CEPs do usuário");
            }
        }

        private IActionResult RetornarCepsPorUsuario(IEnumerable<Cep> ceps)
        {
            var cepsConvertidos = _mapper.Map<IEnumerable<RetornoCepModel>>(ceps);

            var resultado = new RetornoCepsPorUsuarioModel();

            foreach (var cep in cepsConvertidos)
            {
                resultado.AdicionarCep(cep);
            }

            return Ok(resultado);
        }
    }
}
