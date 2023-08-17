using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using WeatherApp.Client.Services;
using WeatherApp.Shared.OpenWeatherAPIParser;
using Xunit;
using Xunit.Abstractions;
using FluentAssertions;

namespace WeatherAppTests.OpenAPIParserTests
{
    public class ParseDailyForecastTest : IDisposable
    {
        private readonly ITestOutputHelper output;
        JsonNode dailyNode = null;

        public ParseDailyForecastTest(ITestOutputHelper output)
        {
            this.output = output;

            var json =
                    @"{
	""daily"": [{
			""dt"": 1682697600,
			""sunrise"": 1682676288,
			""sunset"": 1682725877,
			""moonrise"": 1682700420,
			""moonset"": 1682665200,
			""moon_phase"": 0.27,
			""temp"": {
				""day"": 55.87,
				""min"": 50.32,
				""max"": 56.46,
				""night"": 50.63,
				""eve"": 51.91,
				""morn"": 53.02
			},
			""feels_like"": {
				""day"": 54.82,
				""night"": 49.77,
				""eve"": 51.03,
				""morn"": 51.93
			},
			""pressure"": 1019,
			""humidity"": 78,
			""dew_point"": 49.01,
			""wind_speed"": 16.15,
			""wind_deg"": 80,
			""wind_gust"": 34.78,
			""weather"": [{
				""id"": 501,
				""main"": ""Rain"",
				""description"": ""moderate rain"",
				""icon"": ""10d""
			}],
			""clouds"": 100,
			""pop"": 1,
			""rain"": 9.3,
			""uvi"": 1.81
		},
		{
			""dt"": 1682784000,
			""sunrise"": 1682762611,
			""sunset"": 1682812338,
			""moonrise"": 1682790540,
			""moonset"": 1682753340,
			""moon_phase"": 0.3,
			""temp"": {
				""day"": 55.06,
				""min"": 50.74,
				""max"": 56.89,
				""night"": 56.14,
				""eve"": 56.86,
				""morn"": 51.75
			},
			""feels_like"": {
				""day"": 54.82,
				""night"": 56.1,
				""eve"": 56.86,
				""morn"": 51.08
			},
			""pressure"": 1011,
			""humidity"": 97,
			""dew_point"": 53.96,
			""wind_speed"": 13.76,
			""wind_deg"": 89,
			""wind_gust"": 34.18,
			""weather"": [{
				""id"": 501,
				""main"": ""Rain"",
				""description"": ""moderate rain"",
				""icon"": ""10d""
			}],
			""clouds"": 100,
			""pop"": 1,
			""rain"": 9.91,
			""uvi"": 0.42
		}
	]
}";

            long dt = 0;

            JsonNode node = JsonNode.Parse(json);
            dailyNode = node["daily"];
        }

        public void Dispose()
        {
        }

        [Fact]

        public void CanSerialize()
        {
            ForecastDaily expected =
                new ForecastDaily(
                    dt: 1682697600,
                    sunrise: 1682676288,
                    sunset: 1682725877,
                    moonrise: 1682700420,
                    moonset: 1682665200,
                    moonPhase: 0.27,
                    temp: new ForecastDailyTemp(55.87, 50.32, 56.46, 50.63, 51.91, 53.02),
                    feelsLike: new ForecastDailyFeelsLike(54.82, 49.77, 51.03, 51.93),
                    pressure: 1019,
                    humidity: 78,
                    dewPoint: 49.01,
                    windSpeed: 16.15,
                    windDeg: 80,
                    windGust: 34.78,
                    weather: new ForecastWeather[1] { new ForecastWeather(501, "Rain", "moderate rain", "10d") },
                    clouds: 100,
                    pop: 1,
                    rain: 9.3,
                    snow: null,
                    uvi: 1.81);

            ForecastDaily result = JsonSerializer.Deserialize<ForecastDaily>(dailyNode[0]);

            result.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public void ReturnsValidObject()
        {
            ForecastDaily[] expected = new ForecastDaily[2]
            {
                new ForecastDaily(
                    dt: 1682697600,
                    sunrise: 1682676288,
                    sunset: 1682725877,
                    moonrise: 1682700420,
                    moonset: 1682665200,
                    moonPhase: 0.27,
                    temp: new ForecastDailyTemp(55.87,50.32,56.46,50.63,51.91,53.02),
                    feelsLike: new ForecastDailyFeelsLike(54.82,49.77,51.03,51.93),
                    pressure: 1019,
                    humidity: 78,
                    dewPoint: 49.01,
                    windSpeed: 16.15,
                    windDeg: 80,
                    windGust: 34.78,
                    weather: new ForecastWeather[]{new ForecastWeather(501, "Rain", "moderate rain", "10d") },
                    clouds: 100,
                    pop: 1,
                    rain: 9.3,
                    snow: null,
                    uvi: 1.81),
                new ForecastDaily(
                    dt: 1682784000,
                    sunrise: 1682762611,
                    sunset: 1682812338,
                    moonrise: 1682790540,
                    moonset: 1682753340,
                    moonPhase: 0.3,
                    temp: new ForecastDailyTemp(55.06,50.74,56.89,56.14,56.86,51.75),
                    feelsLike: new ForecastDailyFeelsLike(54.82,56.1,56.86,51.08),
                    pressure: 1011,
                    humidity: 97,
                    dewPoint: 53.96,
                    windSpeed:13.76,
                    windDeg: 89,
                    windGust:34.18,
                    weather: new ForecastWeather[]{new ForecastWeather(501, "Rain", "moderate rain", "10d") },
                    clouds: 100,
                    pop: 1,
                    rain:9.91,
                    snow: null,
                    uvi: 0.42)
            };
            output.WriteLine(dailyNode.ToString());

            ForecastDaily[] result = OpenWeatherParser.ParseDailyForecast(dailyNode);

            expected[0].Should().BeEquivalentTo(result[0]);

        }
    }
}
