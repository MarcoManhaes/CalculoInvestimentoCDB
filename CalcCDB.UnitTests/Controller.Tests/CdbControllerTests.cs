using CalcCDB.Controller.Controllers;
using CalcCDB.Domain.Interfaces;
using CalcCDB.Domain.Model;
using CalcCDB.Domain.Services;
using CalcCDB.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CalcCDB.UnitTests.Controller.Tests
{
    [TestFixture]
    public class CdbControllerTests
    {


        [Test]
        public async Task CalcularCdbOkResult()
        {
            decimal valor = 1000.0m;
            int prazoMeses = 12;

            var cdbService = new CdbService(new CdbConfigurationRepository());
            var controller = new CdbController(cdbService);

            IActionResult result = await controller.CalcularCdb(valor, prazoMeses);

            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            if (okResult != null)
            {
                Assert.That(okResult.StatusCode, Is.EqualTo(200));
                var cdb = okResult.Value as Cdb;
                Assert.That(cdb, Is.Not.Null);
            }
        }
        [Test]
        public async Task CalcularCdbReturnsOkResult()
        {
            decimal valor = 1000.0m;
            int prazoMeses = 12;

            var cdbServiceMock = new Mock<ICdbService>();
            cdbServiceMock.Setup(service => service.CalcularValorCDBAsync(valor, prazoMeses))
                .ReturnsAsync(1200.0m);

            cdbServiceMock.Setup(service => service.AplicarDescontoImpostoAsync(valor, prazoMeses))
                .ReturnsAsync(1100.0m);

            var controller = new CdbController(cdbServiceMock.Object);

            IActionResult result = await controller.CalcularCdb(valor, prazoMeses);

            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));

            var cdb = okResult.Value as Cdb;
            Assert.That(cdb, Is.Not.Null);
        }

        [Test]
        public async Task CalcularCdbBadRequest()
        {
            var controller = new CdbController(Mock.Of<ICdbService>());
            controller.ModelState.AddModelError("ChaveQualquer", "MensagemQualquer");
            var result = await controller.CalcularCdb(0, -1); 
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }


    }
}