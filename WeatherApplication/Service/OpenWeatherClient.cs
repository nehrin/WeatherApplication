using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WeatherApplication.Service
{
    public class OpenWeatherClient
    {
        private readonly HttpClient _client;
        public OpenWeatherClient(
            HttpClient client)
        {
            _client = client;
        }

        public async Task<OpenWeatherResponse> GetLatestWeather(string location, string apiKey)
        {
            var query =
                $"q={location}&appid={apiKey}";
            var endPoint = "https://api.openweathermap.org/data/2.5/weather?"+query;
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, endPoint);
            var response = await _client.SendAsync(httpRequestMessage);
            var responseString = await response.Content.ReadAsStringAsync();

            return new OpenWeatherResponse { StatusCode = response.StatusCode, Data = JsonConvert.DeserializeObject<OpenWeatherResponseData>(responseString) };
        }
    }
}
