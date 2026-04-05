using Application.WeatherForecasts.Response;
using MediatR;

namespace Application.WeatherForecasts.Query;

public record WeatherForecastCity(string city) 
    : IRequest<IEnumerable<WeatherForecastResponse>> { }