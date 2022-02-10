using System.Collections.Generic;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult RetornarBadRequest(IEnumerable<string> mensagens)
        {
            return BadRequest(new RetornoErroModel(mensagens));
        }

        protected IActionResult RetornarListaOk(object valor)
        {
            var lista = (valor as IEnumerable<object>);

            return Ok(new RetornoListaModel(valor, lista.Count()));
        }
    }
}
