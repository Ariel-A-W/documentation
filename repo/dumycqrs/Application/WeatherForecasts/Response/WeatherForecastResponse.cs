namespace Application.WeatherForecasts.Response;

public record WeatherForecastResponse
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; } 
    public decimal GetScaleCelsius { get; set; }
    public decimal GetScaleFaranheit { get; set; }
    public decimal GetScaleKelvin { get; set; }
    public string? Summary { get; set; }
    public string? City { get; set; }
}
