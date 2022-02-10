using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Repositorios
{
    public interface ICepRepositorio
    {
        Task<IEnumerable<Cep>> ObterCepsPorUsuario(string idUsuario);
    }
}
