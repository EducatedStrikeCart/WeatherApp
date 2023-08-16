using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.Shared.OpenWeatherAPIParser
{

    public class ForecastMinutely
    {
		//  Time of the forecasted data, unix, UTC
		[JsonPropertyName("dt")]
		public long Dt { get; set; }

		// Precipitation, mm/h
		[JsonPropertyName("precipitation")]
		public long Precipitation { get; set; }

		public ForecastMinutely(long dt, long precipitation)
		{
			Dt = dt;
			Precipitation = precipitation;
		}

		public override bool Equals(object? obj)
		{
			return obj is ForecastMinutely minutely &&
				   Dt == minutely.Dt &&
				   Precipitation == minutely.Precipitation;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Dt, Precipitation);
		}
	}
}
