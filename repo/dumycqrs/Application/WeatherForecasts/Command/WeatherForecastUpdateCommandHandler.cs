using Application.WeatherForecasts.Response;
using Domain.WeatherForecasts;
using MediatR;

namespace Application.WeatherForecasts.Command;

public sealed class WeatherForecastUpdateCommandHandler
    : IRequestHandler<WeatherForecastUpdateCommand, IEnumerable<WeatherForecastResponse>>
{
    private readonly IWeatherForecast _weatherForecast;

    public WeatherForecastUpdateCommandHandler(IWeatherForecast weatherForecast)
    {
        _weatherForecast = weatherForecast;
    }

    public async Task<IEnumerable<WeatherForecastResponse>> Handle(
        WeatherForecastUpdateCommand request, 
        CancellationToken cancellationToken
    )
    {
        var upRegistro = new WeatherForecast(
            request.Id,
            request.Date!.Value,
            new Temperatures(request.Temperatures!.Value),
            new Summary(request!.Summary!),
            new City(request!.City!)
        );

        var registro = _weatherForecast.UpdateTemperature(
            upRegistro
        );

        if (registro is null || registro.Count() == 0)
        {
            var nulo = new List<WeatherForecastResponse>();
            return nulo;
        }

        var outRegistro = new List<WeatherForecastResponse>();
        outRegistro.Add(new WeatherForecastResponse
        {
            Id = upRegistro.Id,
            Date = upRegistro.Date,
            GetScaleCelsius = upRegistro.Temperatures!.GetScaleCelsius(),
            GetScaleFaranheit = upRegistro.Temperatures!.GetScaleFaranheit(),
            GetScaleKelvin = upRegistro.Temperatures!.GetScaleKelvin(),
            Summary = upRegistro.Summary!.value,
            City = upRegistro.City!.value
        });

        return outRegistro;
    }
}