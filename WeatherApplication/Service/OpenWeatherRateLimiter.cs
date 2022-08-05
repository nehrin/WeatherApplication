namespace WeatherApplication.Service
{
    public class OpenWeatherRateLimiter : IOpenWeatherRateLimiter
    {
        private OpenWeatherClient _openWeatherClient { get; set; }
        private RateLimiter _rateLimiter;
        private List<string> _apiKeys = new List<string>() { "8b7535b42fe1c551f18028f64e8688f7", "9f933451cebf1fa39de168a29a4d9a79", "8b8a4948ec70ed79a1d35796ddd00e90", "fae5fad767d8af907d8226bfdc82f5cc", "c2498bcc3de952568fd5e13f7f5b21d9" };
        public OpenWeatherRateLimiter()
        {
            _openWeatherClient = new OpenWeatherClient(new HttpClient());
            _rateLimiter = new RateLimiter();
        }

        public async Task<string?> GetLatestWeather(string location, string baseUrl)
        {
            foreach(string apiKey in _apiKeys) {
                var result = _rateLimiter.CheckLimiter(apiKey);
                if (result.Equals("WithInLimit")) { 
                    var notFound = "not found.";
                    OpenWeatherResponse openWeatherResponse = await _openWeatherClient.GetLatestWeather(location, apiKey, baseUrl);
                    if (!new HttpResponseMessage(openWeatherResponse.StatusCode).IsSuccessStatusCode)
                    {
                        return notFound;
                    }
                    return (openWeatherResponse?.Data?.weather != null && openWeatherResponse?.Data?.weather.Count > 0) ? openWeatherResponse?.Data?.weather[0].description : notFound;
                }
            }
            return "OutOfLimit";
        }

    }
}
