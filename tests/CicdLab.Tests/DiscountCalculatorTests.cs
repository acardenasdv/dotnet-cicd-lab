using CicdLab.Application;
using Xunit;

namespace CicdLab.Tests;

public class DiscountCalculatorTests
{
    private readonly DiscountCalculator _sut = new();

    [Theory]
    [InlineData(100, 10, 90)]
    [InlineData(200, 50, 100)]
    [InlineData(50, 0, 50)]
    public void ApplyDiscount_ConDescuentoValido_CalculaPrecioCorrecto(decimal price, decimal discount, decimal expected)
    {
        var result = _sut.ApplyDiscount(price, discount);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ApplyDiscount_ConPrecioNegativo_LanzaExcepcion()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _sut.ApplyDiscount(-10, 10));
    }

    [Fact]
    public void ApplyDiscount_ConDescuentoMayorA100_LanzaExcepcion()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _sut.ApplyDiscount(100, 150));
    }
}
