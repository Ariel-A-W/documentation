using Domain.WeatherForecasts;
using MediatR;

namespace Application.WeatherForecasts.Command;

public sealed class WeatherForecastRemoveCommandHandler
    : IRequestHandler<WeatherForecastRemoveCommand, int>
{
    private readonly IWeatherForecast _weatherForecast;

    public WeatherForecastRemoveCommandHandler(IWeatherForecast weatherForecast)
    {
        _weatherForecast = weatherForecast;
    }

    public Task<int> Handle(WeatherForecastRemoveCommand request, CancellationToken cancellationToken)
    {
        var regRemove = _weatherForecast.RemoveTemperature(request.Id);
        return Task.Run(() => regRemove);
    }
}
