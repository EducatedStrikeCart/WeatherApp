using System.Text.Json.Serialization;

namespace WeatherApp.Shared.OpenWeatherAPIParser
{
	public class ForecastDailyTemp
	{
		// Min daily temperature.
		[JsonPropertyName("min")]
		public double Min { get; set; }

		// Max daily temperature.
		[JsonPropertyName("max")]
		public double Max { get; set; }

		// Day temperature 
		[JsonPropertyName("day")]
		public double Day { get; set; }

		//Night temperature
		[JsonPropertyName("night")]
		public double Night { get; set; }

		// Evening temperature.
		[JsonPropertyName("eve")]
		public double Eve { get; set; }

		// Morning temperature
		[JsonPropertyName("morn")]
		public double Morn { get; set; }

		public ForecastDailyTemp(double day, double min, double max, double night, double eve, double morn)
		{
			Day = day;
			Min = min;
			Max = max;
			Night = night;
			Eve = eve;
			Morn = morn;
		}

		public override bool Equals(object? obj)
		{
			return obj is ForecastDailyTemp temp &&
				   Min == temp.Min &&
				   Max == temp.Max &&
				   Day == temp.Day &&
				   Night == temp.Night &&
				   Eve == temp.Eve &&
				   Morn == temp.Morn;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Min, Max, Day, Night, Eve, Morn);
		}
	}
}