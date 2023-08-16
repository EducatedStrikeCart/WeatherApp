using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using WeatherApp.Client.Services;
using WeatherApp.Shared.OpenWeatherAPIParser;
using Xunit;
using Xunit.Abstractions;
using FluentAssertions;
using System.IO.Pipes;

namespace WeatherAppTests.OpenAPIParserTests
{
	public class ParseDailyForecastTest:IDisposable
	{
        private readonly ITestOutputHelper output;
		JsonNode dailyNode = null;
        public ParseDailyForecastTest(ITestOutputHelper output) {
            this.output = output;

			var json =
					@"{ ""daily"": [
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
                    }]
                }";
			JsonNode node = JsonNode.Parse(json);
			 dailyNode = node["daily"];
		}

		public void Dispose()
		{
		}

		[Fact]
		public void ReturnsValidObject()
		{
            ForecastDaily[] expected = new ForecastDaily[1]
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
            };
            ForecastDaily[] result = OpenWeatherParser.ParseDailyForecast(dailyNode);
			expected[0].GetHashCode().Should().Be(result[0].GetHashCode());
			//expected[0].Should().BeEquivalentTo(result[0]); TODO: fix
		}
	}
}
