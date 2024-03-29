using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Repositorios;

namespace Infra.Repositorios
{
    public class CepRepositorio : ICepRepositorio
    {
        public Task<IEnumerable<Cep>> ObterCepsPorUsuario(string idUsuario)
        {
            return Task.Run(() => CepsFake.Where(x => x.IdUsuario == idUsuario));
        }

        public Task AdicionarCep(Cep cep)
        {
            return Task.Run(() => CepsFake.Append(cep));
        }

        public Task<Cep> ObterCepPorUsuario(string idUsuario, string valorCep)
        {
            return Task.Run(() => CepsFake.FirstOrDefault(x => x.IdUsuario == idUsuario && x.Valor == valorCep));
        }

        private IEnumerable<Cep> CepsFake
        {
            get
            {
                return new Cep[]
                {
                    new Cep("12345-678", "Nome 1", "Logradouro 1", "Bairro 1", "Cidade 1", "UF 1", "123456"),
                    new Cep("87654-321", "Nome 2", "Logradouro 2", "Bairro 2", "Cidade 2", "UF 2", "123456"),
                    new Cep("12345-678", "Nome 2", "Logradouro 2", "Bairro 2", "Cidade 2", "UF 2", "654321")
                };
            }
        }
    }
}
