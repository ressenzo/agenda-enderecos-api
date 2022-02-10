using System.Collections.Generic;

namespace Api.Models
{
    public class RetornoErroModel
    {
        public IEnumerable<string> Erros { get; }

        public RetornoErroModel(IEnumerable<string> erros)
        {
            Erros = erros;
        }
    }
}
