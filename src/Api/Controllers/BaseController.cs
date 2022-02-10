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
    }
}
