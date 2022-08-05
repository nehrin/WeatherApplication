namespace WeatherApplication.Service
{
    public interface IOpenWeatherRateLimiter
    {
        Task<string?> GetLatestWeather(string location, string baseUrl);
    }
}
