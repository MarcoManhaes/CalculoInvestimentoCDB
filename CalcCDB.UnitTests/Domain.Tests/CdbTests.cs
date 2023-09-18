using CalcCDB.Domain.Model;

namespace CalcCDB.UnitTests.Domain.Tests
{
    [TestFixture]
    public class CdbTests
    {
        [Test]
        public void ValorBrutoCorrectValue()
        {
            decimal expectedValorBruto = 1000.0m;
            var cdb = new Cdb
            {
                ValorBruto = expectedValorBruto
            };
            decimal actualValorBruto = cdb.ValorBruto;
            Assert.That(actualValorBruto, Is.EqualTo(expectedValorBruto));
        }

        [Test]
        public void ValorLiquidoCorrectValue()
        {
            decimal expectedValorLiquido = 900.0m;
            var cdb = new Cdb
            {
                ValorLiquido = expectedValorLiquido
            };

            decimal actualValorLiquido = cdb.ValorLiquido;
            Assert.That(actualValorLiquido, Is.EqualTo(expectedValorLiquido));
        }

        [Test]
        public void Cdb_ValorBruto_GetSet()
        {
            decimal valorEsperado = 1000m;
            var cdb = new Cdb
            {
                ValorBruto = valorEsperado,
            };
            
            decimal valorObtido = cdb.ValorBruto;
            Assert.That(valorObtido, Is.EqualTo(valorEsperado));
        }

        [Test]
        public void Cdb_ValorLiquido_GetSet()
        {
            decimal valorEsperado = 900m;
            var cdb = new Cdb
            {
                ValorLiquido = valorEsperado
            };  

            decimal valorObtido = cdb.ValorLiquido;
            Assert.That(valorObtido, Is.EqualTo(valorEsperado));
        }

        [Test]
        public void Cdb_ValorDesconto_GetSet()
        {
            decimal valorEsperado = 100m;
            var cdb = new Cdb{
                ValorDesconto = valorEsperado
            };

            decimal valorObtido = cdb.ValorDesconto;

            Assert.That(valorObtido, Is.EqualTo(valorEsperado));
        }
    }
}