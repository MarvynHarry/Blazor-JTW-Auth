// WeatherForecast.cs

namespace BlazorExample.Shared
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public string UserName { get; set; } // NOTE: THIS LINE IS NEWLY ADDED

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}