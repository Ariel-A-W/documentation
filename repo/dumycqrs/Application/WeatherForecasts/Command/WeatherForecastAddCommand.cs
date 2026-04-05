using MediatR;

namespace Application.WeatherForecasts.Command;

public record WeatherForecastAddCommand() : IRequest<Guid> 
{
    public DateTime? Date { set; get; }
    public decimal? Temperatures { set; get; }
    public string? Summary { get; set;  }
    public string? City { get; set; }
}
