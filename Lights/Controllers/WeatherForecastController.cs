using Microsoft.AspNetCore.Mvc;
using PhilipsHueAPI.Models.Classes;

namespace Lights.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public void Get()
        {
            HueBridgeV2 bridge = new HueBridgeV2(new Uri("http://192.168.1.212"));
            bridge.Connect();
            bridge.ChangeLightOnStatus("3", false);
        }
    }
}