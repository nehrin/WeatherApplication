using System.Collections.Generic;

namespace WeatherApplication.Service
{
    public class RateLimiter
    {
        private static readonly List<Request> _requests = new List<Request>();

        private const double _perHourInSeconds = 3600;
        private const int _rateLimit = 1;

        public string CheckLimiter(string apiKey)
        {
            _requests.Add(new Request() { ApiKey = apiKey, Time = DateTime.Now });

            var requestsDuringRateLimit = _requests.Where(w => w.ApiKey.Equals(apiKey) && (DateTime.Now - w.Time).TotalSeconds < _perHourInSeconds).ToArray();

            if (requestsDuringRateLimit.Count() > _rateLimit)
            {
                foreach(Request time in _requests.Where(w => w.ApiKey.Equals(apiKey) && w.Time > DateTime.Now))
                    _requests.Remove(time);
                return "OutOfLimit";
            }

            return "WithInLimit";
        }
    }

    public class Request
    {
        public string ApiKey { get; set; }
        public DateTime Time { get; set; }
    }
}