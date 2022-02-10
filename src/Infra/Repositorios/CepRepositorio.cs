using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Repositorios;

namespace Infra.Repositorios
{
    public class CepRepositorio : ICepRepositorio
    {
        public Task<IEnumerable<Cep>> ObterCeps()
        {
            return Task.Run(() => CepsFake);
        }

        private IEnumerable<Cep> CepsFake
        {
            get
            {
                return new Cep[]
                {
                    new Cep("12345-678", "Nome 1", "Logradouro 1", "Bairro 1", "Cidade 1", "UF 1"),
                    new Cep("87654-321", "Nome 2", "Logradouro 2", "Bairro 2", "Cidade 2", "UF 2")
                };
            }
        }
    }
}
