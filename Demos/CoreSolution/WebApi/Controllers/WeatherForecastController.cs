using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly List<string> Summaries = new()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            if (Request.Headers.Authorization.Count > 0)
            {
                foreach(var item in Request.Headers.Authorization)
                {
                    Console.WriteLine($"{item}");
                }
            }
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Count)]
            })
            .ToArray();
        }
        [HttpGet("{date}",Name = "GetSingleWeatherForecast")]
        public WeatherForecast GetSingle(DateTime date)
        {
            return new WeatherForecast
            {
                Date = date,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries.Last()
            };
        }
        [HttpPost]
        public IActionResult Post(WeatherForecast item)
        {
            Summaries.Add(item.Summary!);
            return CreatedAtAction(nameof(GetSingle), new { date = item.Date }, item);
        }
    }
}