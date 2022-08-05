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

        public async Task<OpenWeatherResponse> GetLatestWeather(string location, string apiKey, string baseUrl)
        {
            var query =
                $"q={location}&appid={apiKey}";
            var endPoint = baseUrl + query;
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, endPoint);
            var response = await _client.SendAsync(httpRequestMessage);
            var responseString = await response.Content.ReadAsStringAsync();

            return new OpenWeatherResponse { StatusCode = response.StatusCode, Data = JsonConvert.DeserializeObject<OpenWeatherResponseData>(responseString) };
        }
    }
}
