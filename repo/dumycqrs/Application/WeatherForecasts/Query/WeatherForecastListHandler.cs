using Application.WeatherForecasts.Response;
using Domain.WeatherForecasts;
using MediatR;

namespace Application.WeatherForecasts.Query;

public sealed class WeatherForecastListHandler
    : IRequestHandler<WeatherForecastList, IEnumerable<WeatherForecastResponse>>
{
    private readonly IWeatherForecast _weatherForecast;

    public WeatherForecastListHandler(IWeatherForecast weatherForecast)
    {
        _weatherForecast = weatherForecast;
    }

    public async Task<IEnumerable<WeatherForecastResponse>> Handle(
        WeatherForecastList request,
        CancellationToken cancellationToken
    )
    {
        var temps = _weatherForecast.GetListTemperatures();
        var list = new List<WeatherForecastResponse>();
        foreach (var temp in temps)
        {
            list.Add(new WeatherForecastResponse
            {
                Id = temp.Id,
                Date = temp.Date,
                GetScaleCelsius = temp.Temperatures!.GetScaleCelsius(),
                GetScaleFaranheit = temp.Temperatures!.GetScaleFaranheit(),
                GetScaleKelvin = temp.Temperatures!.GetScaleKelvin(),
                Summary = temp.Summary!.value,
                City = temp.City!.value
            });
        }
        return list; 
    }
}