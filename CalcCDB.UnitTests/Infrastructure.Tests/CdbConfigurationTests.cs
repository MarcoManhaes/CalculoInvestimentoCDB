
using CalcCDB.Infrastructure.Configuration;
using System.Security.Cryptography;

namespace CalcCDB.UnitTests.Infrastructure.Tests;

[TestFixture]
public class CdbConfigurationTests
{
    [Test]
    public void TaxaTbExpectedResult()
    {
        var cdbConfiguration = CdbConfiguration.Instance;
        decimal result = cdbConfiguration.TaxaTb;
        Assert.That(result, Is.EqualTo(1.08m));
    }

    [Test]
    public void TaxaCdiExpectedResult()
    {
        var cdbConfiguration = CdbConfiguration.Instance;
        decimal result = cdbConfiguration.TaxaCdi;
        Assert.That(result, Is.EqualTo(0.009m));
    }

    [Test]
    public void TabelaImpostoValidValues()
    {
        var cdbConfiguration = CdbConfiguration.Instance;
        var tabelaImposto = cdbConfiguration.TabelaImposto;

        Assert.Multiple(() =>
        {
            Assert.That(tabelaImposto.ContainsKey(6), Is.True);
            Assert.That(tabelaImposto[6], Is.EqualTo(0.225m));

            Assert.That(tabelaImposto.ContainsKey(12), Is.True);
            Assert.That(tabelaImposto[12], Is.EqualTo(0.20m));
        });
    }
    
}