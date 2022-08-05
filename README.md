# WeatherApplication

This application is a front end React js application backed up by C# .NET 6.0 web api. The back-end API enforces rate limiting then calls OpenWeatherMap.com with its API keys. API Key is rate limited to 5 weather reports an hour. Here is a demo video of the application with a rate limit set to 1 per api key:  https://www.loom.com/share/7c528acd48af4359999651bd2bd1e96c

To Run please clone the code to your local folder and have a visual studio suitable for running .NET 6.0 preferably visual studio 2022 with react js.
Please open the solution in the visual studio and run WeatherApplication. API and front end React applications are configured to run simultaneously when you Run WeatherApplication.

The application contains 5 api keys to use https://openweathermap.org/. It applies a rate limiter which only allows 5 requests for each api key per hour. It alternates each key when limit is reached on any given key. If all api keys reached limit for requesting, it prompts the user saying too many requests made.
