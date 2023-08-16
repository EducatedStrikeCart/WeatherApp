

using System.Text.Json.Serialization;

namespace WeatherApp.Shared.OpenWeatherAPIParser
{
	public class ForecastCurrent : ForecastBasic
	{

		// Temperature. Units - default: kelvin, metric: Celsius, imperial: Fahrenheit. 
		[JsonPropertyName("temp")]
		public double Temp { get; set; }

		// Temperature. This temperature parameter accounts for the human perception of weather. Units – default: kelvin, metric: Celsius, imperial: Fahrenheit.
		[JsonPropertyName("feels_like")]
		public double FeelsLike { get; set; }

		//  Average visibility, metres. The maximum value of the visibility is 10km
		[JsonPropertyName("visibility")]
		public int Visibility { get; set; }

		public ForecastCurrent(
			long dt,
			long sunrise,
			long sunset,
			double temp,
			double feelsLike,
			long pressure,
			long humidity,
			double dewPoint,
			double uvi,
			long clouds,
			int visibility,
			double windSpeed,
			double? windGust,
			long windDeg,
			double? rain,
			double? snow,
			ForecastWeather[] weather) : base(
			dt,
			 sunrise,
			 sunset,
			 pressure,
			 humidity,
			 dewPoint,
			 uvi,
			 clouds,
			 windSpeed,
			 windGust,
			 windDeg,
			 rain,
			 snow,
			 weather)
		{
			Temp = temp;
			FeelsLike = feelsLike;
			Visibility = visibility;
		}
	}
}