using System.Collections.Generic;

namespace Api.Models
{
    public class RetornoCepsPorUsuarioModel : RetornoListaModel
    {
        public List<RetornoCepModel> Ceps { get; set; } = new List<RetornoCepModel>();

        public void AdicionarCep(RetornoCepModel cep)
        {
            Ceps.Add(cep);
            AdicionarTamanho();
        }
    }
}
