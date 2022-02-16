using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Repositorios;
using Dominio.Servicos;
using Servicos.Excecoes;

namespace Servicos.Servicos
{
    public class AdicionarCepServico : IAdicionarCepServico
    {
        private readonly ICepRepositorio _cepRepositorio;

        public AdicionarCepServico(ICepRepositorio cepRepositorio)
        {
            _cepRepositorio = cepRepositorio;
        }

        public async Task AdicionarCep(Cep cep)
        {
            ValidarCep(cep);

            if (await CepJaAdicionado(cep.IdUsuario, cep.Valor))
            {
                var erros = new List<string>()
                {
                    "CEP já adicionado para o usuário informado"
                };
                throw new BadRequestExcecao(erros);
            }

            throw new System.NotImplementedException();
        }

        private void ValidarCep(Cep cep)
        {
            if (!cep.Valida)
            {
                throw new BadRequestExcecao(cep.Mensagens);
            }
        }

        private async Task<bool> CepJaAdicionado(string idUsuario, string valorCep)
        {
            var cep = await _cepRepositorio.ObterCepPorUsuario(idUsuario, valorCep);

            return cep != null;
        }
    }
}
