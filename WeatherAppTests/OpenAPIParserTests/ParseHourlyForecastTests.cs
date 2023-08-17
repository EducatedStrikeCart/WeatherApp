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
            var json = @"""hourly"": [
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
		{
			""dt"": 1682661600,
			""temp"": 51.04,
			""feels_like"": 49.84,
			""pressure"": 1021,
			""humidity"": 85,
			""dew_point"": 46.71,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 7.9,
			""wind_deg"": 99,
			""wind_gust"": 19.91,
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
			""dt"": 1682665200,
			""temp"": 51.71,
			""feels_like"": 50.52,
			""pressure"": 1021,
			""humidity"": 84,
			""dew_point"": 47.05,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 8.25,
			""wind_deg"": 97,
			""wind_gust"": 20.51,
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
			""dt"": 1682668800,
			""temp"": 52.38,
			""feels_like"": 51.21,
			""pressure"": 1020,
			""humidity"": 83,
			""dew_point"": 47.37,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 8.37,
			""wind_deg"": 96,
			""wind_gust"": 20.85,
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
			""dt"": 1682672400,
			""temp"": 52.9,
			""feels_like"": 51.75,
			""pressure"": 1020,
			""humidity"": 82,
			""dew_point"": 47.57,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 8.68,
			""wind_deg"": 90,
			""wind_gust"": 21.39,
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
			""dt"": 1682676000,
			""temp"": 53.02,
			""feels_like"": 51.93,
			""pressure"": 1019,
			""humidity"": 83,
			""dew_point"": 47.57,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 10.2,
			""wind_deg"": 86,
			""wind_gust"": 23.69,
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
			""dt"": 1682679600,
			""temp"": 53.31,
			""feels_like"": 52.14,
			""pressure"": 1019,
			""humidity"": 81,
			""dew_point"": 47.39,
			""uvi"": 0.09,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 10.27,
			""wind_deg"": 92,
			""wind_gust"": 25.77,
			""weather"": [
				{
					""id"": 804,
					""main"": ""Clouds"",
					""description"": ""overcast clouds"",
					""icon"": ""04d""
				}
			],
			""pop"": 0
		},
		{
			""dt"": 1682683200,
			""temp"": 54.48,
			""feels_like"": 53.26,
			""pressure"": 1020,
			""humidity"": 77,
			""dew_point"": 47.34,
			""uvi"": 0.36,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 10.76,
			""wind_deg"": 98,
			""wind_gust"": 26.4,
			""weather"": [
				{
					""id"": 804,
					""main"": ""Clouds"",
					""description"": ""overcast clouds"",
					""icon"": ""04d""
				}
			],
			""pop"": 0
		},
		{
			""dt"": 1682686800,
			""temp"": 55,
			""feels_like"": 53.82,
			""pressure"": 1019,
			""humidity"": 77,
			""dew_point"": 47.68,
			""uvi"": 0.63,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 11.68,
			""wind_deg"": 99,
			""wind_gust"": 27.16,
			""weather"": [
				{
					""id"": 804,
					""main"": ""Clouds"",
					""description"": ""overcast clouds"",
					""icon"": ""04d""
				}
			],
			""pop"": 0.26
		},
		{
			""dt"": 1682690400,
			""temp"": 55.87,
			""feels_like"": 54.68,
			""pressure"": 1019,
			""humidity"": 75,
			""dew_point"": 47.75,
			""uvi"": 1.18,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 12.64,
			""wind_deg"": 99,
			""wind_gust"": 28.14,
			""weather"": [
				{
					""id"": 804,
					""main"": ""Clouds"",
					""description"": ""overcast clouds"",
					""icon"": ""04d""
				}
			],
			""pop"": 0.36
		},
		{
			""dt"": 1682694000,
			""temp"": 56.46,
			""feels_like"": 55.33,
			""pressure"": 1019,
			""humidity"": 75,
			""dew_point"": 48.34,
			""uvi"": 1.77,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 12.93,
			""wind_deg"": 97,
			""wind_gust"": 27.94,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 0.62,
			""rain"": {
				""1h"": 0.17
			}
		},
		{
			""dt"": 1682697600,
			""temp"": 55.87,
			""feels_like"": 54.82,
			""pressure"": 1019,
			""humidity"": 78,
			""dew_point"": 49.01,
			""uvi"": 1.67,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 14,
			""wind_deg"": 99,
			""wind_gust"": 28.52,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 0.92,
			""rain"": {
				""1h"": 0.39
			}
		},
		{
			""dt"": 1682701200,
			""temp"": 55.6,
			""feels_like"": 54.75,
			""pressure"": 1018,
			""humidity"": 83,
			""dew_point"": 50.27,
			""uvi"": 1.81,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 14.85,
			""wind_deg"": 98,
			""wind_gust"": 28.41,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 0.67
			}
		},
		{
			""dt"": 1682704800,
			""temp"": 55.31,
			""feels_like"": 54.54,
			""pressure"": 1017,
			""humidity"": 85,
			""dew_point"": 50.68,
			""uvi"": 1.69,
			""clouds"": 100,
			""visibility"": 9526,
			""wind_speed"": 15.41,
			""wind_deg"": 99,
			""wind_gust"": 29.73,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 0.7
			}
		},
		{
			""dt"": 1682708400,
			""temp"": 53.51,
			""feels_like"": 52.79,
			""pressure"": 1017,
			""humidity"": 90,
			""dew_point"": 50.4,
			""uvi"": 0.9,
			""clouds"": 100,
			""visibility"": 9299,
			""wind_speed"": 15.82,
			""wind_deg"": 95,
			""wind_gust"": 30.76,
			""weather"": [
				{
					""id"": 501,
					""main"": ""Rain"",
					""description"": ""moderate rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 1.83
			}
		},
		{
			""dt"": 1682712000,
			""temp"": 52.88,
			""feels_like"": 52.11,
			""pressure"": 1016,
			""humidity"": 90,
			""dew_point"": 49.69,
			""uvi"": 0.61,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 15.1,
			""wind_deg"": 96,
			""wind_gust"": 30.22,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 0.76
			}
		},
		{
			""dt"": 1682715600,
			""temp"": 52.43,
			""feels_like"": 51.6,
			""pressure"": 1016,
			""humidity"": 90,
			""dew_point"": 49.17,
			""uvi"": 0.33,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 16.02,
			""wind_deg"": 87,
			""wind_gust"": 30.71,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 0.54
			}
		},
		{
			""dt"": 1682719200,
			""temp"": 51.91,
			""feels_like"": 51.03,
			""pressure"": 1016,
			""humidity"": 90,
			""dew_point"": 48.72,
			""uvi"": 0.06,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 14.45,
			""wind_deg"": 80,
			""wind_gust"": 29.62,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 0.46
			}
		},
		{
			""dt"": 1682722800,
			""temp"": 50.99,
			""feels_like"": 50.02,
			""pressure"": 1015,
			""humidity"": 90,
			""dew_point"": 48.15,
			""uvi"": 0.01,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 16.15,
			""wind_deg"": 80,
			""wind_gust"": 32.55,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 0.66
			}
		},
		{
			""dt"": 1682726400,
			""temp"": 50.56,
			""feels_like"": 49.59,
			""pressure"": 1016,
			""humidity"": 91,
			""dew_point"": 47.68,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 15.57,
			""wind_deg"": 82,
			""wind_gust"": 33.55,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10n""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 0.4
			}
		},
		{
			""dt"": 1682730000,
			""temp"": 50.34,
			""feels_like"": 49.35,
			""pressure"": 1016,
			""humidity"": 91,
			""dew_point"": 47.59,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 15.03,
			""wind_deg"": 79,
			""wind_gust"": 33.02,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10n""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 0.65
			}
		},
		{
			""dt"": 1682733600,
			""temp"": 50.32,
			""feels_like"": 49.39,
			""pressure"": 1015,
			""humidity"": 92,
			""dew_point"": 47.91,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 8933,
			""wind_speed"": 14.85,
			""wind_deg"": 81,
			""wind_gust"": 33.76,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10n""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 0.92
			}
		},
		{
			""dt"": 1682737200,
			""temp"": 50.63,
			""feels_like"": 49.77,
			""pressure"": 1015,
			""humidity"": 93,
			""dew_point"": 48.45,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 14.54,
			""wind_deg"": 86,
			""wind_gust"": 34.78,
			""weather"": [
				{
					""id"": 501,
					""main"": ""Rain"",
					""description"": ""moderate rain"",
					""icon"": ""10n""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 1.15
			}
		},
		{
			""dt"": 1682740800,
			""temp"": 50.74,
			""feels_like"": 49.87,
			""pressure"": 1014,
			""humidity"": 93,
			""dew_point"": 48.56,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 13.24,
			""wind_deg"": 91,
			""wind_gust"": 33.62,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10n""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 0.92
			}
		},
		{
			""dt"": 1682744400,
			""temp"": 51.1,
			""feels_like"": 50.32,
			""pressure"": 1014,
			""humidity"": 94,
			""dew_point"": 49.14,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 13.76,
			""wind_deg"": 89,
			""wind_gust"": 34.18,
			""weather"": [
				{
					""id"": 501,
					""main"": ""Rain"",
					""description"": ""moderate rain"",
					""icon"": ""10n""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 1.08
			}
		},
		{
			""dt"": 1682748000,
			""temp"": 51.3,
			""feels_like"": 50.59,
			""pressure"": 1013,
			""humidity"": 95,
			""dew_point"": 49.71,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 13.31,
			""wind_deg"": 90,
			""wind_gust"": 33.6,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10n""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 0.97
			}
		},
		{
			""dt"": 1682751600,
			""temp"": 51.73,
			""feels_like"": 51.06,
			""pressure"": 1012,
			""humidity"": 95,
			""dew_point"": 50.05,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 13.24,
			""wind_deg"": 88,
			""wind_gust"": 32.59,
			""weather"": [
				{
					""id"": 501,
					""main"": ""Rain"",
					""description"": ""moderate rain"",
					""icon"": ""10n""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 1.1
			}
		},
		{
			""dt"": 1682755200,
			""temp"": 51.85,
			""feels_like"": 51.21,
			""pressure"": 1012,
			""humidity"": 95,
			""dew_point"": 50.29,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 12.97,
			""wind_deg"": 86,
			""wind_gust"": 32.3,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10n""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 0.99
			}
		},
		{
			""dt"": 1682758800,
			""temp"": 51.84,
			""feels_like"": 51.19,
			""pressure"": 1012,
			""humidity"": 95,
			""dew_point"": 50.18,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 13.62,
			""wind_deg"": 87,
			""wind_gust"": 32.19,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10n""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 0.95
			}
		},
		{
			""dt"": 1682762400,
			""temp"": 51.75,
			""feels_like"": 51.08,
			""pressure"": 1012,
			""humidity"": 95,
			""dew_point"": 50.05,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 13.38,
			""wind_deg"": 86,
			""wind_gust"": 30.67,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10n""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 0.44
			}
		},
		{
			""dt"": 1682766000,
			""temp"": 51.82,
			""feels_like"": 51.17,
			""pressure"": 1012,
			""humidity"": 95,
			""dew_point"": 50.05,
			""uvi"": 0.01,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 13.02,
			""wind_deg"": 79,
			""wind_gust"": 29.84,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 0.41
			}
		},
		{
			""dt"": 1682769600,
			""temp"": 52.14,
			""feels_like"": 51.57,
			""pressure"": 1012,
			""humidity"": 96,
			""dew_point"": 50.63,
			""uvi"": 0.04,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 12.12,
			""wind_deg"": 76,
			""wind_gust"": 27.45,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 1,
			""rain"": {
				""1h"": 0.71
			}
		},
		{
			""dt"": 1682773200,
			""temp"": 52.39,
			""feels_like"": 51.85,
			""pressure"": 1012,
			""humidity"": 96,
			""dew_point"": 51.13,
			""uvi"": 0.13,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 11.25,
			""wind_deg"": 71,
			""wind_gust"": 26.04,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 0.76,
			""rain"": {
				""1h"": 0.39
			}
		},
		{
			""dt"": 1682776800,
			""temp"": 53.04,
			""feels_like"": 52.61,
			""pressure"": 1011,
			""humidity"": 97,
			""dew_point"": 51.93,
			""uvi"": 0.24,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 11.07,
			""wind_deg"": 74,
			""wind_gust"": 27.16,
			""weather"": [
				{
					""id"": 804,
					""main"": ""Clouds"",
					""description"": ""overcast clouds"",
					""icon"": ""04d""
				}
			],
			""pop"": 0.76
		},
		{
			""dt"": 1682780400,
			""temp"": 53.94,
			""feels_like"": 53.6,
			""pressure"": 1011,
			""humidity"": 97,
			""dew_point"": 52.83,
			""uvi"": 0.36,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 10.87,
			""wind_deg"": 78,
			""wind_gust"": 26.62,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 0.72,
			""rain"": {
				""1h"": 0.11
			}
		},
		{
			""dt"": 1682784000,
			""temp"": 55.06,
			""feels_like"": 54.82,
			""pressure"": 1011,
			""humidity"": 97,
			""dew_point"": 53.96,
			""uvi"": 0.39,
			""clouds"": 100,
			""visibility"": 9310,
			""wind_speed"": 8.84,
			""wind_deg"": 77,
			""wind_gust"": 22.75,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 0.76,
			""rain"": {
				""1h"": 0.31
			}
		},
		{
			""dt"": 1682787600,
			""temp"": 55.33,
			""feels_like"": 55.11,
			""pressure"": 1010,
			""humidity"": 97,
			""dew_point"": 54.21,
			""uvi"": 0.42,
			""clouds"": 100,
			""visibility"": 7502,
			""wind_speed"": 8.01,
			""wind_deg"": 76,
			""wind_gust"": 21.61,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 0.72,
			""rain"": {
				""1h"": 0.4
			}
		},
		{
			""dt"": 1682791200,
			""temp"": 55.8,
			""feels_like"": 55.63,
			""pressure"": 1010,
			""humidity"": 97,
			""dew_point"": 54.75,
			""uvi"": 0.39,
			""clouds"": 100,
			""visibility"": 8477,
			""wind_speed"": 8.01,
			""wind_deg"": 73,
			""wind_gust"": 21.88,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 0.72,
			""rain"": {
				""1h"": 0.33
			}
		},
		{
			""dt"": 1682794800,
			""temp"": 56.1,
			""feels_like"": 55.98,
			""pressure"": 1009,
			""humidity"": 97,
			""dew_point"": 55.11,
			""uvi"": 0.33,
			""clouds"": 100,
			""visibility"": 10000,
			""wind_speed"": 8.12,
			""wind_deg"": 70,
			""wind_gust"": 20.74,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 0.55,
			""rain"": {
				""1h"": 0.31
			}
		},
		{
			""dt"": 1682798400,
			""temp"": 56.43,
			""feels_like"": 56.34,
			""pressure"": 1009,
			""humidity"": 97,
			""dew_point"": 55.38,
			""uvi"": 0.22,
			""clouds"": 100,
			""visibility"": 6627,
			""wind_speed"": 8.01,
			""wind_deg"": 67,
			""wind_gust"": 19.82,
			""weather"": [
				{
					""id"": 804,
					""main"": ""Clouds"",
					""description"": ""overcast clouds"",
					""icon"": ""04d""
				}
			],
			""pop"": 0.51
		},
		{
			""dt"": 1682802000,
			""temp"": 56.77,
			""feels_like"": 56.75,
			""pressure"": 1009,
			""humidity"": 98,
			""dew_point"": 55.87,
			""uvi"": 0.12,
			""clouds"": 100,
			""visibility"": 5587,
			""wind_speed"": 6.2,
			""wind_deg"": 66,
			""wind_gust"": 16.82,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 0.51,
			""rain"": {
				""1h"": 0.18
			}
		},
		{
			""dt"": 1682805600,
			""temp"": 56.86,
			""feels_like"": 56.86,
			""pressure"": 1009,
			""humidity"": 98,
			""dew_point"": 56.1,
			""uvi"": 0.09,
			""clouds"": 100,
			""visibility"": 5457,
			""wind_speed"": 5.46,
			""wind_deg"": 69,
			""wind_gust"": 15.75,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 0.52,
			""rain"": {
				""1h"": 0.18
			}
		},
		{
			""dt"": 1682809200,
			""temp"": 56.89,
			""feels_like"": 56.93,
			""pressure"": 1009,
			""humidity"": 99,
			""dew_point"": 56.08,
			""uvi"": 0.02,
			""clouds"": 100,
			""visibility"": 5278,
			""wind_speed"": 4.25,
			""wind_deg"": 63,
			""wind_gust"": 12.97,
			""weather"": [
				{
					""id"": 500,
					""main"": ""Rain"",
					""description"": ""light rain"",
					""icon"": ""10d""
				}
			],
			""pop"": 0.52,
			""rain"": {
				""1h"": 0.13
			}
		},
		{
			""dt"": 1682812800,
			""temp"": 56.68,
			""feels_like"": 56.7,
			""pressure"": 1009,
			""humidity"": 99,
			""dew_point"": 56.1,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 5312,
			""wind_speed"": 5.37,
			""wind_deg"": 57,
			""wind_gust"": 12.77,
			""weather"": [
				{
					""id"": 804,
					""main"": ""Clouds"",
					""description"": ""overcast clouds"",
					""icon"": ""04n""
				}
			],
			""pop"": 0.5
		},
		{
			""dt"": 1682816400,
			""temp"": 56.5,
			""feels_like"": 56.5,
			""pressure"": 1010,
			""humidity"": 99,
			""dew_point"": 55.96,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 5253,
			""wind_speed"": 5.28,
			""wind_deg"": 58,
			""wind_gust"": 12.06,
			""weather"": [
				{
					""id"": 804,
					""main"": ""Clouds"",
					""description"": ""overcast clouds"",
					""icon"": ""04n""
				}
			],
			""pop"": 0.22
		},
		{
			""dt"": 1682820000,
			""temp"": 56.28,
			""feels_like"": 56.26,
			""pressure"": 1010,
			""humidity"": 99,
			""dew_point"": 55.63,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 4457,
			""wind_speed"": 5.55,
			""wind_deg"": 60,
			""wind_gust"": 11.95,
			""weather"": [
				{
					""id"": 804,
					""main"": ""Clouds"",
					""description"": ""overcast clouds"",
					""icon"": ""04n""
				}
			],
			""pop"": 0.17
		},
		{
			""dt"": 1682823600,
			""temp"": 56.14,
			""feels_like"": 56.1,
			""pressure"": 1009,
			""humidity"": 99,
			""dew_point"": 55.53,
			""uvi"": 0,
			""clouds"": 100,
			""visibility"": 706,
			""wind_speed"": 5.55,
			""wind_deg"": 63,
			""wind_gust"": 11.99,
			""weather"": [
				{
					""id"": 804,
					""main"": ""Clouds"",
					""description"": ""overcast clouds"",
					""icon"": ""04n""
				}
			],
			""pop"": 0.13
		}
	],
	";
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
            ForecastCurrent result = OpenWeatherParser.ParseCurrentForecast(currentNode);

            result.Should().BeEquivalentTo(expected);
        }
    }




}

