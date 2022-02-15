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
using System.Linq;
using System;

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
            var cepsRetornoRepositorio = new List<Cep>
            {
                new Cep("12345-678", "Nome 1", "Logradouro 1", "Bairro 1", "Cidade 1", "UF 1", "123456"),
                new Cep("87654-321", "Nome 2", "Logradouro 2", "Bairro 2", "Cidade 2", "UF 2", "123456")
            };
            var cepsRetornoMapper = new List<RetornoCepModel>
            {
                new RetornoCepModel { Bairro = "Bairro 1" },
                new RetornoCepModel { Bairro = "Bairro 2" }
            };
            var controller = Controller;
            _cepRepositorio.Setup(x => x.ObterCepsPorUsuario(It.IsAny<string>()))
                .ReturnsAsync(cepsRetornoRepositorio);
            _mapper.Setup(x => x.Map<IEnumerable<RetornoCepModel>>(It.IsAny<IEnumerable<Cep>>()))
                .Returns(cepsRetornoMapper);

            // Act
            var resultado = await controller.ObterCepsPorUsuario("123456");

            // Assert
            Assert.IsType<OkObjectResult>(resultado);
            
            var resultadoOk = resultado as OkObjectResult;
            Assert.NotNull(resultadoOk);
            
            var objetoRetornado = resultadoOk.Value as RetornoCepsPorUsuarioModel;
            Assert.Equal(cepsRetornoRepositorio.Count, objetoRetornado.Tamanho);
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData(null)]
        public async Task IdUsuarioInvalido_BadRequest(string idUsuario)
        {
            // Arrange
            var controller = Controller;

            // Act
            var resultado = await controller.ObterCepsPorUsuario(idUsuario);

            //Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
            
            var resultadoBadRequest = resultado as BadRequestObjectResult;
            Assert.NotNull(resultadoBadRequest);
            
            var objetoRetornado = resultadoBadRequest.Value as RetornoErroModel;
            Assert.Equal(1, objetoRetornado.Erros.Count());
        }

        [Fact]
        public async Task CepsNaoEncontrados_NoContent()
        {
            // Arrange
            var controller = Controller;

            // Act
            var resultado = await controller.ObterCepsPorUsuario("123456");

            //Assert
            Assert.IsType<NoContentResult>(resultado);
            
            var resultadoNoContent = resultado as NoContentResult;
            Assert.NotNull(resultadoNoContent);
        }

        [Fact]
        public async Task ErroInterno_InternalServerError()
        {
            // Arrange
            var controller = Controller;
            _cepRepositorio.Setup(x => x.ObterCepsPorUsuario(It.IsAny<string>()))
                .ThrowsAsync(new Exception("Erro de banco de dados"));

            // Act
            var resultado = await controller.ObterCepsPorUsuario("123456");
            
            // Assert
            Assert.IsType<ObjectResult>(resultado);
            
            var resultadoObjeto = resultado as ObjectResult;
            Assert.NotNull(resultadoObjeto);
            Assert.Equal(500, resultadoObjeto.StatusCode);
            
            var objetoRetornado = resultadoObjeto.Value as RetornoErroModel;
            Assert.Equal(1, objetoRetornado.Erros.Count());
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
