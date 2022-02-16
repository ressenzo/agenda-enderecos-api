using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Repositorios;
using Moq;
using Servicos.Excecoes;
using Servicos.Servicos;
using Xunit;

namespace Testes.Servicos
{
    public class AdicionarCepServicoTeste
    {
        private readonly Mock<ICepRepositorio> _cepRepositorio;

        public AdicionarCepServicoTeste()
        {
            _cepRepositorio = new Mock<ICepRepositorio>();
        }

        [Fact]
        public async Task EntidadeInvalida_ExcecaoBadRequest()
        {
            // Arrange
            var cepInvalido = new Cep(null, "Nome", "Logradouro", "Bairro", "Cidade", "Uf", "Id");
            var quantidadeMensagens = cepInvalido.Mensagens.Count();
            var servico = Servico;            

            // Assert
            var excecao = await Assert.ThrowsAsync<BadRequestExcecao>(
                // Act
                () => servico.AdicionarCep(cepInvalido)
            );

            // Assert
            Assert.Equal(quantidadeMensagens, excecao.Mensagens.Count());
        }

        [Fact]
        public async Task CepJaAdicionadoParaUsuario_ExcecaoBadRequest()
        {
            // Arrange
           var cep = new Cep("12345-678", "Nome", "Logradouro", "Bairro", "Cidade", "Uf", "Id");
            _cepRepositorio.Setup(x => x.ObterCepPorUsuario(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(cep);
            var servico = Servico;            

            // Assert
            var excecao = await Assert.ThrowsAsync<BadRequestExcecao>(
                // Act
                () => servico.AdicionarCep(cep)
            );

            // Assert
            Assert.Single(excecao.Mensagens);
        }

        private AdicionarCepServico Servico
        {
            get
            {
                return new AdicionarCepServico(_cepRepositorio.Object);
            }
        }
    }
}
