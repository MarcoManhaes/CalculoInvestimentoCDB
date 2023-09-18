using CalcCDB.Domain.Model;
using CalcCDB.Infrastructure.Repository;

namespace CalcCDB.UnitTests.Infrastructure.Tests;

/// <summary>
/// Abordagem de testes sem utilização de MOCKS
/// </summary>
[TestFixture]
public class CdbConfigurationRepositoryTests
{
    private CdbConfigurationRepository _cdbConfigurationRepository = new();

    [SetUp]
    public void Setup()
    {
        _cdbConfigurationRepository = new CdbConfigurationRepository();
    }

    [Test]
    public async Task ObterConstantesExpectedResult()
    {
        var result = await _cdbConfigurationRepository.ObterConstantesAsync();
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void ObterImpostoPeriodoExpectedResult()
    {
        int meses = 6;
        decimal result = _cdbConfigurationRepository.ObterImpostoPeriodo(meses);
        Assert.That(result, Is.EqualTo(0.225m));
    }

    [Test]
    public void ObterImpostoPeriodoExpectedResult2()
    {
        int meses = 12;
        decimal result = _cdbConfigurationRepository.ObterImpostoPeriodo(meses);
        Assert.That(result, Is.EqualTo(0.20m));
    }

    [Test]
    public void ObterImpostoPeriodoExpectedResult3()
    {
        int meses = 24;
        decimal result = _cdbConfigurationRepository.ObterImpostoPeriodo(meses);
        Assert.That(result, Is.EqualTo(0.175m));
    }

    [Test]
    public void ObterImpostoPeriodoExpectedResult4()
    {
        int meses = 30;
        decimal result = _cdbConfigurationRepository.ObterImpostoPeriodo(meses);
        Assert.That(result, Is.EqualTo(0.15m));
    }

    [Test]
    public void ObterTaxaCdiExpectedResult()
    {
        decimal result = _cdbConfigurationRepository.ObterTaxaCDI();
        Assert.That(result, Is.EqualTo(0.009m));
    }

    [Test]
    public void ObterTaxaTbExpectedResult()
    {
        decimal result = _cdbConfigurationRepository.ObterTaxaTB();
        Assert.That(result, Is.EqualTo(1.08m));
    }
}