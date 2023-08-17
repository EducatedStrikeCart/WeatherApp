using FluentAssertions;
using System.Text.Json;
using System.Text.Json.Nodes;
using WeatherApp.Shared.OpenWeatherAPIParser;
using Xunit;

namespace WeatherAppTests.OpenAPIParserTests
{
    public class ForecastDailyTempTests
    {
		[Fact]
		public void CanDeserialize()
		{
			var json = @"{
	""temp"": {
		""day"": 55.87,
		""min"": 50.32,
		""max"": 56.46,
		""night"": 50.63,
		""eve"": 51.91,
		""morn"": 53.02
	}
}";
			var node = JsonNode.Parse(json);
			var currentNode = node["temp"];

			ForecastDailyTemp expected = new ForecastDailyTemp(55.87, 50.32, 56.46, 50.63, 51.91, 53.02);

            ForecastDailyTemp result = JsonSerializer.Deserialize<ForecastDailyTemp>(currentNode);

            result.Should().BeEquivalentTo(expected);
		}
	}
}
