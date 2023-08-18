using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Shared.Models
{
	public record Coordinates
	{
		public double Latitude { get; init; }
		public double Longitude { get; init; }

		public Coordinates(double latitude, double longitude)
		{
			Latitude = latitude;
			Longitude = longitude;
		}
	}
}
