using Microsoft.AspNetCore.Mvc;

namespace LogExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get(string? a)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("TestMethod")]
        public ActionResult TestMethod(string a)
        {
            if(a == "test")
            {
                _logger.LogError("Error, test yazýlamaz.");
                return BadRequest("test yazýlamaz");
            }

            return Ok("Ok");
        }

        [HttpGet]
        [Route("TestMethod2")]
        public ActionResult TestMethod2(string a)
        {
            if (a == "test")
            {
                throw new Exception("Parametre olarak test deðeri yazýlamaz.");
            }

            return Ok("Ok");
        }
    }
}