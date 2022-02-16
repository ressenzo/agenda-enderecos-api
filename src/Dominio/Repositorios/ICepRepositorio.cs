using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Repositorios
{
    public interface ICepRepositorio
    {
        Task<IEnumerable<Cep>> ObterCepsPorUsuario(string idUsuario);

        Task<Cep> ObterCepPorUsuario(string idUsuario, string valorCep);

        Task AdicionarCep(Cep cep);
    }
}
