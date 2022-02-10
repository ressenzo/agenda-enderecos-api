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
            var ceps = await _cepRepositorio.ObterCepsPorUsuario(idUsuario);

            var resultado = _mapper.Map<IEnumerable<Cep>, IEnumerable<RetornoCepModel>>(ceps);

            return Ok(new { ceps = resultado, tamanho = resultado.Count() });
        }
    }
}
