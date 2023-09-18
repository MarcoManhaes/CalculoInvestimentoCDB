using CalcCDB.Controller;
using CalcCDB.Domain.Interfaces;
using CalcCDB.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Moq;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Net;
using Microsoft.AspNetCore.Http;
using CalcCDB.Controller.Controllers;
using CalcCDB.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Net.Http;

namespace CalcCDB.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void ConfigureDependencyInjectionRegisters()
        {
            var services = new ServiceCollection();

            Program.ConfigureDependencyInjection(services);

            var serviceProvider = services.BuildServiceProvider();
            var cdbConfigurationRepository = serviceProvider.GetService<ICdbConfigurationRepository>();
            var cdbService = serviceProvider.GetService<ICdbService>();

            Assert.Multiple(() =>
            {
                Assert.That(cdbConfigurationRepository, Is.Not.Null);
            });
            Assert.That(cdbService, Is.Not.Null);
        }

        [Test]
        public void ConfigureSwaggerSettings()
        {
            var builder = WebApplication.CreateBuilder(Array.Empty<string>());

            Program.ConfigureSweggerGen(builder);

            
            var swaggerGenServiceDescriptor = builder.Services.FirstOrDefault(descriptor =>
                descriptor.ServiceType == typeof(ISwaggerProvider));
            
            Assert.That(swaggerGenServiceDescriptor, Is.Not.Null);

        }

        [Test]
        public void ConfigureCorsPolicy()
        {
            var builder = WebApplication.CreateBuilder(Array.Empty<string>());

            Program.ConfigureCors(builder);

            var app = builder.Build();
            var httpContext = new DefaultHttpContext();
            var policy = app.Services.GetRequiredService<ICorsPolicyProvider>().GetPolicyAsync(httpContext, "PolicyCors");
            
            Assert.That(policy, Is.Not.Null);
        }

        [TestFixture]
        public class CdbControllerTests
        {
            private Mock<ICdbService> _cdbServiceMock;
            private CdbController _controller;

            [SetUp]
            public void Setup()
            {
                _cdbServiceMock = new Mock<ICdbService>();
                _controller = new CdbController(_cdbServiceMock.Object);
            }

            [Test]
            public async Task CalcularCdbReturnsOk()
            {
                decimal valor = 1000m;
                int prazoMeses = 12;
                var expectedResult = new Cdb
                {
                    ValorBruto = 500m,
                    ValorLiquido = 480m
                };
                


                _cdbServiceMock.Setup(service => service.CalcularValorCDBAsync(valor, prazoMeses))
                    .ReturnsAsync(500m); 

                _cdbServiceMock.Setup(service => service.AplicarDescontoImpostoAsync(valor, prazoMeses))
                    .ReturnsAsync(480m); 

                IActionResult result = await _controller.CalcularCdb(valor, prazoMeses);

                Assert.That(result, Is.InstanceOf<OkObjectResult>());


                var okResult = (OkObjectResult)result;

                Assert.That(okResult.Value, Is.Not.Null);

                Assert.That(okResult.Value, Is.Not.Null);
                Assert.That(okResult.Value, Is.InstanceOf<Cdb>());

                var cdb = (Cdb)okResult.Value;


                Assert.Multiple(() =>
                {
                    Assert.That(expectedResult, Is.Not.Null);
                    Assert.That(cdb, Is.Not.Null);
                    Assert.That(cdb?.ValorBruto, Is.EqualTo(expectedResult.ValorBruto));
                });

                Assert.That(cdb, Is.Not.Null);
                Assert.That(cdb?.ValorBruto, Is.EqualTo(expectedResult.ValorBruto));

            }
        }
    }
}
