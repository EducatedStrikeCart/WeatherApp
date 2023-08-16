using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Shared;
using WeatherApp.Shared.OpenWeatherAPIParser;
using Xunit;

namespace WeatherAppTests.OpenAPIParserTests
{
	public class testest
	{
		[Fact]
		public void test()
		{
			ForecastDaily a = new ForecastDaily(
				  1682697600,
				  1682676288,
				  1682725877,
				  1682700420,
				  1682665200,
				  0.27,
				  new ForecastDailyTemp(55.87, 50.32, 56.46, 50.63, 51.91, 53.02),
				  new ForecastDailyFeelsLike(54.82, 49.77, 51.03, 51.93),
				  1019,
				  78,
				  49.01,
				  16.15,
				  80,
				  34.78,
				  new ForecastWeather[] { new ForecastWeather(501, "Rain", "moderate rain", "10d") },
				  100,
				  1,
				  9.3,
				  null,
				  1.81
				  );
			ForecastDaily b = new ForecastDaily(
				  1682697600,
				  1682676288,
				  1682725877,
				  1682700420,
				  1682665200,
				  0.27,
				  new ForecastDailyTemp(55.87, 50.32, 56.46, 50.63, 51.91, 53.02),
				  new ForecastDailyFeelsLike(54.82, 49.77, 51.03, 51.93),
				  1019,
				  78,
				  49.01,
				  16.15,
				  80,
				  34.78,
				  new ForecastWeather[] { new ForecastWeather(501, "Rain", "moderate rain", "10d") },
				  100,
				  1,
				  9.3,
				  null,
				  1.81
				  );
			a.GetHashCode().Should().Be(b.GetHashCode());
		}
	}
}
