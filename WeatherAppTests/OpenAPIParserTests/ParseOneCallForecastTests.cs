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
    public class ParseOneCallForecastTests
    {
        [Fact]
        public void ReturnsValidObject()
        {
            var json =
                @"{
	""lat"": 39.9527,
	""lon"": -75.1635,
	""timezone"": ""America/New_York"",
	""timezone_offset"": -14400,
	""current"": {
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
			}
		]
	},
	""minutely"": [
		{
			""dt"": 1682657580,
			""precipitation"": 0
		},
		{
			""dt"": 1682657640,
			""precipitation"": 0
		},
		{
			""dt"": 1682657700,
			""precipitation"": 0
		},
		{
			""dt"": 1682657760,
			""precipitation"": 0
		},
		{
			""dt"": 1682657820,
			""precipitation"": 0
		}
	],
	""hourly"": [
		{
			""dt"": 1682654400,
			""temp"": 51.08,
			""feels_like"": 49.87,
			""pressure"": 1021,
			""humidity"": 85,
			""dew_point"": 46.74,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 7.61,
			""wind_deg"": 93,
			""wind_gust"": 18.57,
			""weather"": [
				{
					""id"": 804,
					""main"": ""Clouds"",
					""description"": ""overcast clouds"",
					""icon"": ""04n""
				}
			],
			""pop"": 0
		},
		{
			""dt"": 1682658000,
			""temp"": 50.34,
			""feels_like"": 49.12,
			""pressure"": 1021,
			""humidity"": 86,
			""dew_point"": 46.33,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 8.21,
			""wind_deg"": 93,
			""wind_gust"": 19.98,
			""weather"": [
				{
					""id"": 804,
					""main"": ""Clouds"",
					""description"": ""overcast clouds"",
					""icon"": ""04n""
				}
			],
			""pop"": 0
		}
	],
	""daily"": [
		{
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
			""weather"": [
				{
					""id"": 501,
					""main"": ""Rain"",
					""description"": ""moderate rain"",
					""icon"": ""10d""
				}
			],
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
			""weather"": [
				{
					""id"": 501,
					""main"": ""Rain"",
					""description"": ""moderate rain"",
					""icon"": ""10d""
				}
			],
			""clouds"": 100,
			""pop"": 1,
			""rain"": 9.91,
			""uvi"": 0.42
		}
	]
}";

            Forecast result = OpenWeatherParser.ParseOneCallForecast(json);

            Forecast expected = new Forecast(
                timezone: "America/New_York",
                timezone_offset: 25200,
                lat: 39.9527,
                lon: -75.1635,
                current: new ForecastCurrent(
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
                    weather: new ForecastWeather[1]
                        {
                            new ForecastWeather(804,"Clouds","overcast clouds","04n")
                        },
                    pop: null
                    ),
                daily: new ForecastDaily[2]
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
                },
                hourly: new ForecastCurrent[2]
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
                },
                minutely: new ForecastMinutely[5]
                {
                    new ForecastMinutely(1682657580, 0),
                    new ForecastMinutely(1682657640, 0),
                    new ForecastMinutely(1682657700, 0),
                    new ForecastMinutely(1682657760, 0),
                    new ForecastMinutely(1682657820, 0),
                }
            );

			result.Should().BeEquivalentTo(expected );
        }
    }
}
