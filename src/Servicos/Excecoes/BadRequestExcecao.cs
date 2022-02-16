using System.Collections.Generic;
using System;

namespace Servicos.Excecoes
{
    public sealed class BadRequestExcecao : Exception
    {
        public IEnumerable<string> Mensagens { get; }

        public BadRequestExcecao(List<string> mensagens)
        {
            Mensagens = mensagens;
        }
    }
}
