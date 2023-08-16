using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using WeatherApp.Client.Services;
using WeatherApp.Shared.OpenWeatherAPIParser;
using Xunit;

namespace WeatherAppTests.OpenAPIParserTests
{
	public class ParseCurrentForecast
	{
		[Fact]
		public void ReturnsValidObject()
		{
			var json = @"{   ""current"": {
        ""dt"": 1682657538,
        ""sunrise"": 1682676288,
        ""sunset"": 1682725877,
        ""temp"": 50.34,
        ""feels_like"": 49.12,
        ""pressure"": 1021,
        ""humidity"": 86,
        ""dew_point"": 46.33,
        ""uvi"": 0,
        ""clouds"": 100,
        ""visibility"": 10000,
        ""wind_speed"": 8.05,
        ""wind_deg"": 80,
        ""weather"": [
            {
                ""id"": 804,
                ""main"": ""Clouds"",
                ""description"": ""overcast clouds"",
                ""icon"": ""04n""
            }]
        }}";
			var node = JsonNode.Parse(json);
			var currentNode = node["current"];

			ForecastCurrent expected = new(
				dt: 1682657538,
				sunrise: 1682676288,
				sunset: 1682725877,
				temp: 50.34,
				feelsLike: 49.12,
				pressure: 1021,
				humidity: 86,
				dewPoint: 46.33,
				uvi: 0,
				clouds: 100,
				visibility: 10000,
				windSpeed: 8.05,
				windGust: null,
				windDeg: 80,
				rain: null,
				snow: null,
				weather: new ForecastWeather[1] {
					new ForecastWeather(804,"Clouds","overcast clouds","04n")
				}
			);

			ForecastCurrent result = OpenWeatherParser.ParseCurrentForecast(currentNode);

			result.Should().BeEquivalentTo(expected);
		}
	}
}
