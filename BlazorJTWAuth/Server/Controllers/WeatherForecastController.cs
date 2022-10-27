// WeatherForecastController.cs
using BlazorExample.Shared;
using BlazorJTWAuth.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorExample.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        [Authorize] // NOTE: THIS LINE OF CODE IS NEWLY ADDED
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                UserName = User.Identity?.Name ?? string.Empty // NOTE: THIS LINE OF CODE IS NEWLY ADDED
            });
        }

        // NOTE: THIS ENTIRE BLOCK OF CODE IS NEWLY ADDED
        [HttpGet("{date}")]
        [Authorize]
        public WeatherForecast Get(DateTime date)
        {
            var rng = new Random();
            return new WeatherForecast
            {
                Date = date,
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                UserName = User.Identity?.Name ?? string.Empty
            };
        }
        // NOTE: END BLOCK
    }
}