using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.Shared.OpenWeatherAPIParser
{
	public class ForecastBasic
	{
		//Current time, Unix, UTC
		[JsonPropertyName("dt")]
		public long Dt { get; set; }

		// Sunrise time, Unix, UTC
		[JsonPropertyName("sunrise")]
		public long Sunrise { get; set; }

		//Sunset time, Unix, UTC
		[JsonPropertyName("sunset")]
		public long Sunset { get; set; }

		// Atmospheric pressure on the sea level, hPa
		[JsonPropertyName("pressure")]
		public long Pressure { get; set; }

		// Humidity, %
		[JsonPropertyName("humidity")]
		public long Humidity { get; set; }

		// Atmospheric temperature (varying according to pressure and humidity) below which water droplets begin to condense and dew can form. Units – default: kelvin, metric: Celsius, imperial: Fahrenheit.
		[JsonPropertyName("dew_point")]
		public double DewPoint { get; set; }

		//  Current UV index
		[JsonPropertyName("uvi")]
		public double Uvi { get; set; }

		//Cloudiness, %
		[JsonPropertyName("clouds")]
		public long Clouds { get; set; }

		// Wind speed. Wind speed. Units – default: metre/sec, metric: metre/sec, imperial: miles/hour.
		[JsonPropertyName("wind_speed")]
		public double WindSpeed { get; set; }

		// (where available) Wind gust. Units – default: metre/sec, metric: metre/sec, imperial: miles/hour.
		[JsonPropertyName("wind_gust")]
		public double? WindGust { get; set; }

		// Wind direction, degrees (meteorological)

		[JsonPropertyName("wind_deg")]
		public long WindDeg { get; set; }

		// (where available) Precipitation, mm/h
		[JsonPropertyName("rain")]
		public double? Rain { get; set; }

		// (where available) Precipitation, mm/h
		[JsonPropertyName("snow")]
		public double? Snow { get; set; }

		// 
		[JsonPropertyName("weather")]
		public ForecastWeather[] Weather { get; set; }

		public ForecastBasic(
			long dt,
			long sunrise,
			long sunset,
			long pressure,
			long humidity,
			double dewPoint,
			double uvi,
			long clouds,
			double windSpeed,
			double? windGust,
			long windDeg,
			double? rain,
			double? snow,
			ForecastWeather[] weather)
		{
			Dt = dt;
			Sunrise = sunrise;
			Sunset = sunset;
			Pressure = pressure;
			Humidity = humidity;
			DewPoint = dewPoint;
			Uvi = uvi;
			Clouds = clouds;
			WindSpeed = windSpeed;
			WindGust = windGust;
			WindDeg = windDeg;
			Rain = rain;
			Snow = snow;
			Weather = weather;
		}
	}
}
