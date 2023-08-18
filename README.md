# WeatherApp
## Description
This is a simple app demonstrating use of OpenWeather's One Call and Geocoder APIs to get weather forecasts at various periods of time
## Demo
1. Before you start, you will need to acquire an API key from OpenWeather (it's free). You will find it at https://home.openweathermap.org/api_keys after signing up and loggin in.    
1. Clone the repository and open the solution in Visual Studio
3. In WeatherApp.Server, you will need to add an API key from OpenWeather into your user secrets: 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In settings.json:
```
{
    "OpenWeatherAPIKey": "YOUR_KEY_GOES_HERE"
}
```
4. Start Debug from WeatherApp.Server or run `dotnet watch` from `...\WeatherApp\Server` in the terminal
5. The website should be launched to your browser and you can play around with it there.
