using Domain.WeatherForecasts;

namespace Infrastructure
{
    public sealed class WeatherForcastRepository : IWeatherForecast
    {
        private static List<WeatherForecast>? _temps;

        public WeatherForcastRepository()
        {
            _temps = new List<WeatherForecast>();
            _temps.AddRange(
                [
                    new WeatherForecast
                    (
                        Guid.Parse("313877cc-a63b-4242-88dc-759eb323f5a0"),
                        DateTime.UtcNow,
                        new Temperatures((decimal)45.31),
                        new Summary(GetSummary("Chilly")),
                        new City(GetCity("Texas"))
                    ),
                    new WeatherForecast
                    (
                        Guid.Parse("313877cc-a63b-4242-88dc-759eb323f5a1"),
                        DateTime.UtcNow,
                        new Temperatures((decimal)12.16),
                        new Summary(GetSummary("Cool")),
                        new City(GetCity("New York"))
                    ),
                    new WeatherForecast
                    (
                        Guid.Parse("313877cc-a63b-4242-88dc-759eb323f5a2"),
                        DateTime.UtcNow,
                        new Temperatures((decimal)10.62),
                        new Summary(GetSummary("Bracing")),
                        new City(GetCity("Washington DC"))
                    ),
                    new WeatherForecast
                    (
                        Guid.Parse("313877cc-a63b-4242-88dc-759eb323f5a3"),
                        DateTime.UtcNow,
                        new Temperatures((decimal)4.55),
                        new Summary(GetSummary("Chilly")),
                        new City(GetCity("Massachusetts"))
                    ),
                ]
            );
        }

        public static IEnumerable<string> GetCities()
        {
            var cities = new List<string>();
            cities.AddRange([
                "New York",
                "Washington DC",
                "Virginia",
                "Massachusetts",
                "Florida"
            ]);
            return cities;
        }

        public static string GetCity(string value)
        {
            var city = GetCities().First(x => x == value);
            return city;
        }

        public static IEnumerable<string> GetListSummaries()
        {
            var summaries = new List<string>();
            summaries.AddRange([
                "Freezing",
                "Bracing",
                "Chilly",
                "Cool",
                "Mild",
                "Warm",
                "Balmy",
                "Hot",
                "Sweltering",
                "Scorching"
            ]);
            return summaries;
        }

        public static string GetSummary(string value)
        {
            var result = GetListSummaries().First(x => x == value);
            return result;
        }

        public static List<WeatherForecast> GetList()
        {
            return _temps!.OrderBy(x => x.Id).ToList();
        }

        public IEnumerable<WeatherForecast> GetListTemperatures()
        {
            return GetList();
        }

        public IEnumerable<WeatherForecast> GetTemperatures(string city)
        {
            var registros = GetList()
                .Where<WeatherForecast>(
                    x => x.City!.value.ToUpper().Equals(city.ToUpper())
                ).AsEnumerable<WeatherForecast>().ToList();

            if (registros is null)
                return Enumerable.Empty<WeatherForecast>();

            var temp = new List<WeatherForecast>();

            foreach (var item in registros)
            {
                temp.Add(
                    new WeatherForecast
                    (
                        item.Id!,
                        item.Date!,
                        item.Temperatures!,
                        item.Summary!,
                        item.City!
                    )
                );
            }

            return temp;
        }

        public Guid AddTemperature(WeatherForecast value)
        {
            _temps!.Add(
                new WeatherForecast
                (
                    value.Id!,
                    value.Date!,
                    value.Temperatures!,
                    value.Summary!,
                    value.City!
                )
            );
            return value!.Id;
        }

        public IEnumerable<WeatherForecast> UpdateTemperature(
            WeatherForecast value
        )
        {
            var registro = GetList()
                .FirstOrDefault<WeatherForecast>(
                    x => x.Id == value.Id
                );

            if (registro is null)
            { 
                var nulo = new List<WeatherForecast>();
                return nulo;
            }

            _temps!.Remove(registro);

            var newRegistro = new WeatherForecast(
                value.Id!,
                value.Date!,
                value.Temperatures!,
                value.Summary!,
                value.City!
            );
            _temps!.Add(newRegistro);

            List<WeatherForecast>? result = [
                new WeatherForecast
                (
                    value.Id!,
                    value.Date!,
                    value.Temperatures!,
                    value.Summary!,
                    value.City!
                )
            ];
            return result;
        }

        public int RemoveTemperature(
            Guid id    
        )
        {
            var registro = GetList()
                .FirstOrDefault<WeatherForecast>(
                    x => x.Id == id
                );

            if (registro is null)
                return 0;

            _temps!.Remove(registro);
            return 1;
        }
    }
}
