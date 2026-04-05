using Domain.WeatherForecasts;

namespace Application.WeatherForecasts
{
    internal class WeatherForecastList : IWeatherForecast
    {
        private readonly IWeatherForecast _weatherForecast;

        public WeatherForecastList(IWeatherForecast weatherForecast)
        {
            _weatherForecast = weatherForecast;
        }

        public IEnumerable<WeatherForecast> GetListTemperatures()
        {
            return _weatherForecast.GetListTemperatures();            
        }
    }
}
