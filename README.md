# WeatherApplication

This application is a front end React js application backed up by C# .NET 6.0 web api.

To Run please clone the code in your local flder and have a visual studio suitable for running .NET 6.0 preferably visual studio 2022 with react js.
Please open the solution in the visual studio and run WeatherApplication. API and front end React applications are configured to run simultaneously when you Run WeatherApplication.

The application contains 5 api keys to use https://openweathermap.org/. It applies a rate limiter which only allows 5 requests for each api key per hour. If it runs out of api keys for requesting it promts the user saying too many request made.
