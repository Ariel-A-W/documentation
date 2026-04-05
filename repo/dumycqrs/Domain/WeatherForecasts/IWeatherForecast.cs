namespace Domain.WeatherForecasts;

public interface IWeatherForecast  
{
    IEnumerable<WeatherForecast> GetListTemperatures();
    IEnumerable<WeatherForecast> GetTemperatures(string city);
    public Guid AddTemperature(WeatherForecast value);
    IEnumerable<WeatherForecast> UpdateTemperature(WeatherForecast value);
    int RemoveTemperature(Guid id);
}
