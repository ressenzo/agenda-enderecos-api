using Dominio.Entidades;
using Xunit;

namespace Testes.Entidades
{
    public class CepTeste
    {
        [Theory]
        [InlineData("12345-67")]
        [InlineData("12345-6789")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("12345-67A")]
        public void ValorCepInvalido_EntidadeInvalida(string valor)
        {
            // Arrange
            var cep = new Cep(valor, "Nome", "Logradouro", "Bairro", "Cidade", "Uf");

            // Act
            var ehValido = cep.Valida;

            // Assert
            Assert.False(ehValido);
        }

        [Theory]
        [InlineData("12345-678", "", "Logradouro", "Bairro", "Cidade", "Uf")]
        [InlineData("12345-678", " ", "Logradouro", "Bairro", "Cidade", "Uf")]
        [InlineData("12345-678", null, "Logradouro", "Bairro", "Cidade", "Uf")]
        [InlineData("12345-678", "Nome", "", "Bairro", "Cidade", "Uf")]
        [InlineData("12345-678", "Nome", " ", "Bairro", "Cidade", "Uf")]
        [InlineData("12345-678", "Nome", null, "Bairro", "Cidade", "Uf")]
        [InlineData("12345-678", "Nome", "Logradouro", "", "Cidade", "Uf")]
        [InlineData("12345-678", "Nome", "Logradouro", " ", "Cidade", "Uf")]
        [InlineData("12345-678", "Nome", "Logradouro", null, "Cidade", "Uf")]
        [InlineData("12345-678", "Nome", "Logradouro", "Bairro", "", "Uf")]
        [InlineData("12345-678", "Nome", "Logradouro", "Bairro", " ", "Uf")]
        [InlineData("12345-678", "Nome", "Logradouro", "Bairro", null, "Uf")]
        [InlineData("12345-678", "Nome", "Logradouro", "Bairro", "Cidade", "")]
        [InlineData("12345-678", "Nome", "Logradouro", "Bairro", "Cidade", " ")]
        [InlineData("12345-678", "Nome", "Logradouro", "Bairro", "Cidade", null)]
        public void CamposVaziosOuNulos_EntidadeInvalida(string valor,
            string nome,
            string logradouro,
            string bairro,
            string cidade,
            string uf
            )
        {
            // Arrange
            var cep = new Cep(valor, nome, logradouro, bairro, cidade, uf);

            // Act
            var ehValido = cep.Valida;

            // Assert
            Assert.False(ehValido);
        }

        [Fact]
        public void ValoresValidos_EntidadeValida()
        {
            // Arrange
            var cep = new Cep("12345-678", "Nome", "Logradouro", "Bairro", "Cidade", "Uf");

            // Act
            var ehValido = cep.Valida;

            // Assert
            Assert.True(ehValido);
        }
    }
}
