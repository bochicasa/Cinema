using Cine.API.Controllers;
using Cine.API.Models;
using Cine.API.Repositories.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CineWebApi.Test.Reserva
{
    public class ReservaWebApiTest
    {
        private readonly Mock<IReservaRepository> _reservaRepositoryMock;
        private readonly Mock<IFuncionesRepository> _funcionesRepositoryMock;
        private readonly Mock<ILogger<ReservaController>> _log;
        public ReservaWebApiTest()
        {
            _reservaRepositoryMock = new Mock<IReservaRepository>();
            _funcionesRepositoryMock = new Mock<IFuncionesRepository>();
            _log = new Mock<ILogger<ReservaController>>();
        }
        [Fact]
        public async void Get_All_funcionesBymovie_success_From_Moq()
        {
            //Arrange
            decimal movieId = 458156;
            var funciones = GetFunciones();
            _funcionesRepositoryMock.Setup(x => x.GetFunctionsByEvent(movieId)).Returns(Task.FromResult<IEnumerable<Funcion>>(funciones));


            //Act
            var reservaController = new ReservaController(_funcionesRepositoryMock.Object, _log.Object, _reservaRepositoryMock.Object);
            var actionResult = await reservaController.GetFuncionesByMovieAsync(movieId);

            var okResult = actionResult.Should().BeOfType<OkObjectResult>().Subject;
            var Result = okResult.Value.Should().BeAssignableTo<IEnumerable<Funcion>>().Subject;
            Result.Count().Should().BeGreaterThan(0);

        }

        [Fact]
        public async void Post_Reserva_BAD_Request_From_Moq()
        {
            //Arrange
            var reservaDummy = GetReserva();
            _reservaRepositoryMock.Setup(x => x.CreateReserva(reservaDummy));

            //Act
            var reservaController = new ReservaController(_funcionesRepositoryMock.Object, _log.Object, _reservaRepositoryMock.Object);
            var actionResult = await reservaController.PostReserva(reservaDummy);

            //Assert
            var okResult = actionResult.Should().BeOfType<BadRequestObjectResult>().Subject;
            var Result = okResult.Value.Equals("Object reference not set to an instance of an object.");
        }


        private Cine.API.Models.Reserva GetReserva()
        {
            return new Cine.API.Models.Reserva()
            {
                Id = 1,
                FechaRes = DateTime.Now,
                Estado = "A",
                NumSil = 1,
                SecCliente = 1,
                Funcion = 1,
                TipoRes = "A"
            };
        }

        private IEnumerable<Funcion> GetFunciones()
        {
            return new List<Funcion>()
            {
                 new Funcion()
                {
                    Id = 1,
                    FechaFun = DateTime.Now
                },
                 new Funcion()
                 {
                    Id = 2,
                    FechaFun = DateTime.Now
                }
            };
        }

    }
}


