namespace Domain.WeatherForecasts;

public class WeatherForecast
{
    public WeatherForecast(
        Guid id,
        DateTime date,
        Temperatures temperatures, 
        Summary summary, 
        City city
    )
    {
        Id = id;
        Date = date;
        Temperatures = temperatures;
        Summary = summary;
        City = city;
    }
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Temperatures? Temperatures { get; set; }
    public Summary? Summary { get; set; }
    public City? City { get; set; }
}
