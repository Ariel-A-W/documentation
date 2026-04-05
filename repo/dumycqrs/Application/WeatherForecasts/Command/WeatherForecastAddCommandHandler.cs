using Domain.WeatherForecasts;
using MediatR;

namespace Application.WeatherForecasts.Command;

public sealed class WeatherForecastAddCommandHandler
    : IRequestHandler<WeatherForecastAddCommand, Guid>
{
    private readonly IWeatherForecast _weatherForecast;

    public WeatherForecastAddCommandHandler(IWeatherForecast weatherForecast)
    {
        _weatherForecast = weatherForecast;
    }

    Task<Guid> IRequestHandler<WeatherForecastAddCommand, Guid>.Handle(
        WeatherForecastAddCommand request, 
        CancellationToken cancellationToken
    )
    {
        var temp = new WeatherForecast(
            Guid.NewGuid(),
            request!.Date!.Value,
            new Temperatures(request.Temperatures!.Value),
            new Summary(request!.Summary!),
            new City(request!.City!)
        );
        var reg = _weatherForecast.AddTemperature(temp);
        return Task.Run(() => reg);
    }
}
