using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.Shared.OpenWeatherAPIParser
{
	public class Forecast
	{
		// Geographical coordinates of the location (latitude)
		[JsonPropertyName("lat")]
		public double Lat { get; set; }

		// Geographical coordinates of the location (longitude)
		[JsonPropertyName("lon")]
		public double Lon { get; set; }
		// Timezone name for the requested location
		[JsonPropertyName("timezone")]
		long Timezone { get; set; }

		// Shift in seconds from UTC
		[JsonPropertyName("timezone_offset")]
		long Timezone_offset { get; set; }

		// Current Weather
		[JsonPropertyName("current")]
		public ForecastCurrent Current { get; set; }

		// Daily Weather
		[JsonPropertyName("daily")]
		public ForecastDaily[] Daily { get; set; }

		// Hourly Weather
		[JsonPropertyName("hourly")]
		public ForecastCurrent[] Hourly { get; set; }

		// Perciptation data per minute
		[JsonPropertyName("minutely")]
		public ForecastMinutely[] Minutely { get; set; }

		public Forecast(
			long timezone,
			long timezone_offset,
			double lat,
			double lon,
			ForecastCurrent current,
			ForecastDaily[] daily,
			ForecastCurrent[] hourly,
			ForecastMinutely[] minutely)
		{
			Timezone = timezone;
			Timezone_offset = timezone_offset;
			Lat = lat;
			Lon = lon;
			Current = current;
			Daily = daily;
			Hourly = hourly;
			Minutely = minutely;
		}
	}
}
