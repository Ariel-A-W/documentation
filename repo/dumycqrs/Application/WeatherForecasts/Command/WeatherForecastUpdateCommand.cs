using Application.WeatherForecasts.Response;
using MediatR;

namespace Application.WeatherForecasts.Command;

public record WeatherForecastUpdateCommand() 
    : IRequest<IEnumerable<WeatherForecastResponse>>
{
    public Guid Id { get; set; }
    public DateTime? Date { set; get; }
    public decimal? Temperatures { set; get; }
    public string? Summary { get; set; }
    public string? City { get; set; }
}
