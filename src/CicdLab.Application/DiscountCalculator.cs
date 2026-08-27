namespace CicdLab.Application;

public class DiscountCalculator
{
    public decimal ApplyDiscount(decimal price, decimal discountPercentage)
    {
        if (price < 0)
            throw new ArgumentOutOfRangeException(nameof(price), "El precio no puede ser negativo.");

        if (discountPercentage is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(discountPercentage), "El descuento debe estar entre 0 y 100.");

        var discountAmount = price * (discountPercentage / 100m);
        return price - discountAmount;
    }
}