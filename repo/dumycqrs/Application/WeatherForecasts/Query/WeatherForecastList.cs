using Application.WeatherForecasts.Response;
using MediatR;

namespace Application.WeatherForecasts.Query;

public record WeatherForecastList() 
    : IRequest<IEnumerable<WeatherForecastResponse>> { }