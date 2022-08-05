using Microsoft.AspNetCore.Mvc;
using WeatherApplication.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherApplication.Controllers
{
    [Route("weather")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        
        private IOpenWeatherRateLimiter openWeatherRateLimiter = new OpenWeatherRateLimiter();
        private IConfiguration _configuration;

        public WeatherController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("location/{location}")]
        public async Task<string> GetAsync(string location)
        {
            var baseUrl = _configuration.GetValue<string>("baseUrl");
            return await openWeatherRateLimiter.GetLatestWeather(location, baseUrl) ?? "not found.";
        }
    }
}
