using Dominio.Entidades;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public interface IAdicionarCepServico
    {
        Task AdicionarCep(Cep cep);
    }
}
