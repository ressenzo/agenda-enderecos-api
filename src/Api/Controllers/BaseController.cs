using System.Collections.Generic;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult RetornarBadRequest(IEnumerable<string> mensagens)
        {
            return BadRequest(new RetornoErroModel(mensagens));
        }

        protected IActionResult RetornarErroInterno(string erro)
        {
            var erros = new List<string>();
            erros.Add(erro);
            return StatusCode(500, new RetornoErroModel(erros));
        }
    }
}
