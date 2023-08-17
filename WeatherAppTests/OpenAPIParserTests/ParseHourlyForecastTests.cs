using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using WeatherApp.Client.Services;
using WeatherApp.Shared.OpenWeatherAPIParser;
using Xunit;

namespace WeatherAppTests.OpenAPIParserTests
{
    public class ParseHourlyForecastTests
    {
        [Fact]
        public void CanParse()
        {
            var json =
                @"{
   ""hourly"":[
      {
         ""dt"":1682654400,
         ""temp"":51.08,
         ""feels_like"":49.87,
         ""pressure"":1021,
         ""humidity"":85,
         ""dew_point"":46.74,
         ""uvi"":0,
         ""clouds"":100,
         ""visibility"":10000,
         ""wind_speed"":7.61,
         ""wind_deg"":93,
         ""wind_gust"":18.57,
         ""weather"":[
            {
               ""id"":804,
               ""main"":""Clouds"",
               ""description"":""overcast clouds"",
               ""icon"":""04n""
            }
         ],
         ""pop"":0
      },
      {
         ""dt"":1682658000,
         ""temp"":50.34,
         ""feels_like"":49.12,
         ""pressure"":1021,
         ""humidity"":86,
         ""dew_point"":46.33,
         ""uvi"":0,
         ""clouds"":100,
         ""visibility"":10000,
         ""wind_speed"":8.21,
         ""wind_deg"":93,
         ""wind_gust"":19.98,
         ""weather"":[
            {
               ""id"":804,
               ""main"":""Clouds"",
               ""description"":""overcast clouds"",
               ""icon"":""04n""
            }
         ],
         ""pop"":0
      }
   ]
}";
            var node = JsonNode.Parse(json);
            var currentNode = node["hourly"];

            ForecastCurrent[] expected = new ForecastCurrent[2]
            {
                new ForecastCurrent(
                    dt: 1682654400,
                    sunrise: null,
                    sunset: null,
                    temp: 51.08,
                    feelsLike: 49.87,
                    pressure: 1021,
                    humidity: 85,
                    dewPoint: 46.74,
                    uvi: 0,
                    clouds: 100,
                    visibility: 10000,
                    windSpeed: 7.61,
                    windDeg: 93,
                    windGust: 18.57,
                    new ForecastWeather[1] { new ForecastWeather(804, "Clouds", "overcast clouds", "04n") },
                    rain: null,
                    snow: null,
                    pop: 0
                    ),
                new ForecastCurrent(
                    dt: 1682658000,
                    sunrise: null,
                    sunset: null,
                    temp: 50.34,
                    feelsLike: 49.12,
                    pressure: 1021,
                    humidity: 86,
                    dewPoint: 46.33,
                    uvi: 0,
                    clouds: 100,
                    visibility: 10000,
                    windSpeed: 8.21,
                    windDeg: 93,
                    windGust: 19.98,
                    new ForecastWeather[1] { new ForecastWeather(804, "Clouds", "overcast clouds", "04n") },
                    rain: null,
                    snow: null,
                    pop: 0
                    )
            };
            ForecastCurrent[] result = OpenWeatherParser.ParseHourlyForecast(currentNode);

            result.Should().BeEquivalentTo(expected);
        }
    }




}

