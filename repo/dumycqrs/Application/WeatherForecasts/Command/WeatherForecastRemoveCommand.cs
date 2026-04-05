using MediatR;

namespace Application.WeatherForecasts.Command;

public record WeatherForecastRemoveCommand() : IRequest<int>
{
    public Guid Id { get; set; }
}
