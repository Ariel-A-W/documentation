namespace Domain.WeatherForecasts;

public record Temperatures(decimal value)
{
    private const decimal CONST_CELSIUS = (Decimal)0.5556;
    private const decimal CONST_KEVIN = (Decimal)273.15;

    public decimal GetScaleCelsius() => value;
    public decimal GetScaleFaranheit() => (32 + (value / CONST_CELSIUS));
    public decimal GetScaleKelvin() => value + CONST_KEVIN;
}