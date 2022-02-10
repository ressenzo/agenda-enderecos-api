using Xunit;
using Api.Controllers;
using Moq;
using Dominio.Repositorios;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using AutoMapper;

namespace Testes.Controllers
{
    public class CepControllerTeste
    {
        private readonly Mock<ICepRepositorio> _cepRepositorio;
        private readonly Mock<IMapper> _mapper;

        public CepControllerTeste()
        {
            _cepRepositorio = new Mock<ICepRepositorio>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task CepsEncontrados_ListaComCepsEOk()
        {
            // Arrange
            var cepsParaRetornar = new List<Cep>
            {
                new Cep("12345-678", "Nome 1", "Logradouro 1", "Bairro 1", "Cidade 1", "UF 1", "123456"),
                new Cep("87654-321", "Nome 2", "Logradouro 2", "Bairro 2", "Cidade 2", "UF 2", "123456")
            };
            var controller = Controller;
            _cepRepositorio.Setup(x => x.ObterCepsPorUsuario(It.IsAny<string>()))
                .ReturnsAsync(cepsParaRetornar);

            // Act
            var resultado = await controller.ObterCepsPorUsuario(It.IsAny<string>());

            // Assert
            Assert.IsType<OkObjectResult>(resultado);
            
            var resultadoOk = resultado as OkObjectResult;
            Assert.NotNull(resultadoOk);
            
            var objetoRetornado = resultadoOk.Value as RetornoCepsPorUsuarioModel;
            Assert.Equal(cepsParaRetornar.Count, objetoRetornado.Tamanho);
        }

        private CepController Controller
        {
            get
            {
                return new CepController(_cepRepositorio.Object,
                    _mapper.Object
                );
            }
        }
    }
}
