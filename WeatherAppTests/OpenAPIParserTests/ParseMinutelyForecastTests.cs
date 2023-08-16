using System.Text.Json.Nodes;
using WeatherApp.Client.Services;
using WeatherApp.Shared.OpenWeatherAPIParser;
using Xunit;
using Xunit.Abstractions;

namespace WeatherAppTests.OpenAPIParserTests
{
	public class ParseMinutelyForecastTests
	{
		private readonly ITestOutputHelper _output;

		public ParseMinutelyForecastTests(ITestOutputHelper output)
		{
			this._output = output;
		}

		[Fact]
		public void ReturnsValidObject()
		{
			var json =
				@"{""minutely"":[

					{
					""dt"": 1682657580,
					""precipitation"": 0

					},
					{
					""dt"": 1682657640,
					""precipitation"": 2

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
					}]
				}";
			JsonNode jsonNode = JsonNode.Parse(json);
			var minutelynode = jsonNode["minutely"];
			var result = OpenWeatherParser.ParseMinutelyForecast(minutelynode);

			ForecastMinutely[] expected = new ForecastMinutely[5]
			{
				new ForecastMinutely(1682657580, 0),
				new ForecastMinutely(1682657640, 2),
				new ForecastMinutely(1682657700, 0),
				new ForecastMinutely(1682657760, 0),
				new ForecastMinutely(1682657820, 0),
			};


			Assert.NotNull(result);
			Assert.Equal(expected, result);
		}
	}
}
