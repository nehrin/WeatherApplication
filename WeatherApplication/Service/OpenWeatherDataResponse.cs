using System.Net;

namespace WeatherApplication.Service
{
    public class OpenWeatherResponse
    {
        public HttpStatusCode StatusCode;
        public OpenWeatherResponseData? Data { get; set; }
    }
    public class OpenWeatherResponseData
    {
        public List<Weather> weather { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string? main { get; set; }
        public string? description { get; set; }
        public string? icon { get; set; }
    }
}