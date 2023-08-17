using FluentAssertions;
using System.Text.Json;
using System.Text.Json.Nodes;
using WeatherApp.Shared.OpenWeatherAPIParser;
using Xunit;

namespace WeatherAppTests.OpenAPIParserTests
{
    public class ForecastDailyFeelsLikeTests
    {
		[Fact]
		public void CanDeserialize()
		{
			var json = @"{
	""feels_like"": {
				""day"": 54.82,
				""night"": 56.1,
				""eve"": 56.86,
				""morn"": 51.08
			}
}";
			var node = JsonNode.Parse(json);
			var currentNode = node["feels_like"];

			ForecastDailyFeelsLike expected = new ForecastDailyFeelsLike(54.82,
                56.1,
				56.86,
				51.08);

            ForecastDailyFeelsLike result = JsonSerializer.Deserialize<ForecastDailyFeelsLike>(currentNode);

            result.Should().BeEquivalentTo(expected);
		}
	}
}
