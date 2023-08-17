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
            var json = @"{
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
		},
		{
			""dt"": 1682657880,
			""precipitation"": 0
		},
		{
			""dt"": 1682657940,
			""precipitation"": 0
		},
		{
			""dt"": 1682658000,
			""precipitation"": 0
		},
		{
			""dt"": 1682658060,
			""precipitation"": 0
		},
		{
			""dt"": 1682658120,
			""precipitation"": 0
		},
		{
			""dt"": 1682658180,
			""precipitation"": 0
		},
		{
			""dt"": 1682658240,
			""precipitation"": 0
		},
		{
			""dt"": 1682658300,
			""precipitation"": 0
		},
		{
			""dt"": 1682658360,
			""precipitation"": 0
		},
		{
			""dt"": 1682658420,
			""precipitation"": 0
		},
		{
			""dt"": 1682658480,
			""precipitation"": 0
		},
		{
			""dt"": 1682658540,
			""precipitation"": 0
		},
		{
			""dt"": 1682658600,
			""precipitation"": 0
		},
		{
			""dt"": 1682658660,
			""precipitation"": 0
		},
		{
			""dt"": 1682658720,
			""precipitation"": 0
		},
		{
			""dt"": 1682658780,
			""precipitation"": 0
		},
		{
			""dt"": 1682658840,
			""precipitation"": 0
		},
		{
			""dt"": 1682658900,
			""precipitation"": 0
		},
		{
			""dt"": 1682658960,
			""precipitation"": 0
		},
		{
			""dt"": 1682659020,
			""precipitation"": 0
		},
		{
			""dt"": 1682659080,
			""precipitation"": 0
		},
		{
			""dt"": 1682659140,
			""precipitation"": 0
		},
		{
			""dt"": 1682659200,
			""precipitation"": 0
		},
		{
			""dt"": 1682659260,
			""precipitation"": 0
		},
		{
			""dt"": 1682659320,
			""precipitation"": 0
		},
		{
			""dt"": 1682659380,
			""precipitation"": 0
		},
		{
			""dt"": 1682659440,
			""precipitation"": 0
		},
		{
			""dt"": 1682659500,
			""precipitation"": 0
		},
		{
			""dt"": 1682659560,
			""precipitation"": 0
		},
		{
			""dt"": 1682659620,
			""precipitation"": 0
		},
		{
			""dt"": 1682659680,
			""precipitation"": 0
		},
		{
			""dt"": 1682659740,
			""precipitation"": 0
		},
		{
			""dt"": 1682659800,
			""precipitation"": 0
		},
		{
			""dt"": 1682659860,
			""precipitation"": 0
		},
		{
			""dt"": 1682659920,
			""precipitation"": 0
		},
		{
			""dt"": 1682659980,
			""precipitation"": 0
		},
		{
			""dt"": 1682660040,
			""precipitation"": 0
		},
		{
			""dt"": 1682660100,
			""precipitation"": 0
		},
		{
			""dt"": 1682660160,
			""precipitation"": 0
		},
		{
			""dt"": 1682660220,
			""precipitation"": 0
		},
		{
			""dt"": 1682660280,
			""precipitation"": 0
		},
		{
			""dt"": 1682660340,
			""precipitation"": 0
		},
		{
			""dt"": 1682660400,
			""precipitation"": 0
		},
		{
			""dt"": 1682660460,
			""precipitation"": 0
		},
		{
			""dt"": 1682660520,
			""precipitation"": 0
		},
		{
			""dt"": 1682660580,
			""precipitation"": 0
		},
		{
			""dt"": 1682660640,
			""precipitation"": 0
		},
		{
			""dt"": 1682660700,
			""precipitation"": 0
		},
		{
			""dt"": 1682660760,
			""precipitation"": 0
		},
		{
			""dt"": 1682660820,
			""precipitation"": 0
		},
		{
			""dt"": 1682660880,
			""precipitation"": 0
		},
		{
			""dt"": 1682660940,
			""precipitation"": 0
		},
		{
			""dt"": 1682661000,
			""precipitation"": 0
		},
		{
			""dt"": 1682661060,
			""precipitation"": 0
		},
		{
			""dt"": 1682661120,
			""precipitation"": 0
		},
		{
			""dt"": 1682661180,
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
		},
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
		},
		{
			""dt"": 1682870400,
			""sunrise"": 1682848935,
			""sunset"": 1682898800,
			""moonrise"": 1682880600,
			""moonset"": 1682841180,
			""moon_phase"": 0.33,
			""temp"": {
				""day"": 61.81,
				""min"": 55.63,
				""max"": 64.76,
				""night"": 60.35,
				""eve"": 64.76,
				""morn"": 56.16
			},
			""feels_like"": {
				""day"": 61.97,
				""night"": 60.69,
				""eve"": 64.83,
				""morn"": 56.12
			},
			""pressure"": 1003,
			""humidity"": 91,
			""dew_point"": 58.87,
			""wind_speed"": 13.31,
			""wind_deg"": 166,
			""wind_gust"": 29.55,
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
			""rain"": 14.73,
			""uvi"": 0.84
		},
		{
			""dt"": 1682956800,
			""sunrise"": 1682935260,
			""sunset"": 1682985261,
			""moonrise"": 1682970720,
			""moonset"": 1682928900,
			""moon_phase"": 0.37,
			""temp"": {
				""day"": 56.35,
				""min"": 49.91,
				""max"": 56.35,
				""night"": 49.91,
				""eve"": 55.09,
				""morn"": 50.52
			},
			""feels_like"": {
				""day"": 53.85,
				""night"": 45.9,
				""eve"": 52.65,
				""morn"": 49.14
			},
			""pressure"": 999,
			""humidity"": 46,
			""dew_point"": 35.42,
			""wind_speed"": 16.13,
			""wind_deg"": 299,
			""wind_gust"": 35.5,
			""weather"": [
				{
					""id"": 501,
					""main"": ""Rain"",
					""description"": ""moderate rain"",
					""icon"": ""10d""
				}
			],
			""clouds"": 2,
			""pop"": 1,
			""rain"": 7.97,
			""uvi"": 5.35
		},
		{
			""dt"": 1683043200,
			""sunrise"": 1683021586,
			""sunset"": 1683071722,
			""moonrise"": 1683060840,
			""moonset"": 1683016560,
			""moon_phase"": 0.4,
			""temp"": {
				""day"": 54.23,
				""min"": 46.22,
				""max"": 58.8,
				""night"": 50.43,
				""eve"": 54.75,
				""morn"": 46.22
			},
			""feels_like"": {
				""day"": 51.89,
				""night"": 48.61,
				""eve"": 53.02,
				""morn"": 42.04
			},
			""pressure"": 1005,
			""humidity"": 54,
			""dew_point"": 37.71,
			""wind_speed"": 15.82,
			""wind_deg"": 260,
			""wind_gust"": 25.93,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""clouds"": 81,
			""pop"": 0.33,
			""rain"": 0.44,
			""uvi"": 0.71
		},
		{
			""dt"": 1683129600,
			""sunrise"": 1683107914,
			""sunset"": 1683158184,
			""moonrise"": 1683151080,
			""moonset"": 1683104220,
			""moon_phase"": 0.43,
			""temp"": {
				""day"": 55.81,
				""min"": 49.96,
				""max"": 57.43,
				""night"": 50.81,
				""eve"": 55.53,
				""morn"": 49.98
			},
			""feels_like"": {
				""day"": 54.01,
				""night"": 49.12,
				""eve"": 53.4,
				""morn"": 49.28
			},
			""pressure"": 1004,
			""humidity"": 62,
			""dew_point"": 42.85,
			""wind_speed"": 11.25,
			""wind_deg"": 264,
			""wind_gust"": 14.45,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""clouds"": 95,
			""pop"": 0.4,
			""rain"": 0.72,
			""uvi"": 1
		},
		{
			""dt"": 1683216000,
			""sunrise"": 1683194243,
			""sunset"": 1683244645,
			""moonrise"": 1683241560,
			""moonset"": 1683192000,
			""moon_phase"": 0.46,
			""temp"": {
				""day"": 54.75,
				""min"": 45.12,
				""max"": 54.82,
				""night"": 46.74,
				""eve"": 51.66,
				""morn"": 45.12
			},
			""feels_like"": {
				""day"": 52.41,
				""night"": 41.58,
				""eve"": 50.09,
				""morn"": 41.95
			},
			""pressure"": 1003,
			""humidity"": 53,
			""dew_point"": 37.76,
			""wind_speed"": 11.81,
			""wind_deg"": 302,
			""wind_gust"": 22.86,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""clouds"": 29,
			""pop"": 0.96,
			""rain"": 2.69,
			""uvi"": 1
		},
		{
			""dt"": 1683302400,
			""sunrise"": 1683280573,
			""sunset"": 1683331106,
			""moonrise"": 1683332160,
			""moonset"": 1683279960,
			""moon_phase"": 0.5,
			""temp"": {
				""day"": 50.97,
				""min"": 42.66,
				""max"": 57.67,
				""night"": 51.51,
				""eve"": 57.67,
				""morn"": 42.66
			},
			""feels_like"": {
				""day"": 49.33,
				""night"": 49.14,
				""eve"": 55.58,
				""morn"": 36.07
			},
			""pressure"": 1006,
			""humidity"": 76,
			""dew_point"": 43.29,
			""wind_speed"": 13.71,
			""wind_deg"": 320,
			""wind_gust"": 32.3,
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
			""rain"": 14.18,
			""uvi"": 1
		}
	]
}";

            Forecast result = OpenWeatherParser.ParseOneCallForecast(json);

            Forecast expected = new Forecast(
                   "America/New_York",
            25200,
           39.9527,
            -75.1635,
            new ForecastCurrent(
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
                },
				pop: null
                ),
            new ForecastDaily[1]
            {
                new ForecastDaily(
                    1682697600,
                    1682676288,
                    1682725877,
                    1682700420,
                    1682665200,
                    0.27,
                    new ForecastDailyTemp(55.87,50.32,56.46,50.63,51.91,53.02),
                    new ForecastDailyFeelsLike(54.82,49.77,51.03,51.93),
                    1019,
                    78,
                    49.01,
                    16.15,
                    80,
                    34.78,
                    new ForecastWeather[]{new ForecastWeather(501, "Rain", "moderate rain", "10d") },
                    100,
                    1,
                    9.3,
                    null,
                    1.81
                    )
            },
            new ForecastCurrent[1] {new ForecastCurrent(dt: 1682657538,
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
                },
				pop: null
            ) },
            new ForecastMinutely[5]
            {
                new ForecastMinutely(1682657580, 0),
                new ForecastMinutely(1682657640, 2),
                new ForecastMinutely(1682657700, 0),
                new ForecastMinutely(1682657760, 0),
                new ForecastMinutely(1682657820, 0),
            }
                );
        }
    }
}
