using System.Collections.Generic;
using System.Linq;

namespace Api.Models
{
    public class RetornoErroModel
    {
        public IEnumerable<string> Erros { get; }
        public int Tamanho { get; }

        public RetornoErroModel(IEnumerable<string> erros)
        {
            Erros = erros;
            Tamanho = erros.Count();
        }
    }
}
