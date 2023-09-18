using CalcCDB.Domain.Services;
using CalcCDB.Infrastructure.Interfaces;
using Moq;

namespace CalcCDB.UnitTests.Domain.Tests
{
    /// <summary>
    /// Abordagem de tests utilizando MOCKS
    /// </summary>
    [TestFixture]
    public class CdbServiceTests
    {
        [Test]
        public async Task CalcularValorCdbAsync()
        {
            decimal valorInicial = 1000.0m;
            int meses = 12;

            var cdbConfigurationRepositoryMock = new Mock<ICdbConfigurationRepository>();
            cdbConfigurationRepositoryMock.Setup(repo => repo.ObterTaxaTB()).Returns(1.08m);
            cdbConfigurationRepositoryMock.Setup(repo => repo.ObterTaxaCDI()).Returns(0.009m);

            var cdbService = new CdbService(cdbConfigurationRepositoryMock.Object);

            // Act
            decimal resultado = await cdbService.CalcularValorCDBAsync(valorInicial, meses);

            decimal resultadoEsperado = 1000.0m * (decimal)Math.Pow(1 + 0.009 * 1.08, 12);
            resultadoEsperado = Math.Round(resultadoEsperado, 2);

            Assert.That(resultado, Is.EqualTo(resultadoEsperado));
        }

        [Test]
        public async Task AplicarDescontoImpostoAsync()
        {
            decimal valorBruto = 1000.0m;
            int meses = 12;


            var cdbConfigurationRepositoryMock = new Mock<ICdbConfigurationRepository>();
            cdbConfigurationRepositoryMock.Setup(repo => repo.ObterImpostoPeriodo(meses)).Returns(0.1m);

            var cdbService = new CdbService(cdbConfigurationRepositoryMock.Object);


            decimal percentualImposto = 0.1m;
            decimal resultadoEsperado = valorBruto - valorBruto * percentualImposto;
            resultadoEsperado = Math.Round(resultadoEsperado, 2);


            decimal resultado = await cdbService.AplicarDescontoImpostoAsync(valorBruto, meses);


            Assert.That(resultado, Is.EqualTo(resultadoEsperado));
        }



        [Test]
        public async Task ObterDescontoImpostoCalculatesDiscount()
        {
            decimal valorBruto = 1000m;
            int meses = 6;
            decimal percentualImposto = 0.15m; 

            var cdbConfigurationRepositoryMock = new Mock<ICdbConfigurationRepository>();
            cdbConfigurationRepositoryMock.Setup(repo => repo.ObterImpostoPeriodo(It.IsAny<int>())).Returns(percentualImposto);

            var cdbService = new CdbService(cdbConfigurationRepositoryMock.Object);

            decimal resultadoDesconto = await cdbService.ObterDescontoImpostoAsync(valorBruto, meses);

            decimal descontoEsperado = valorBruto * percentualImposto;
            Assert.That(resultadoDesconto, Is.EqualTo(descontoEsperado));
        }

    }
}
