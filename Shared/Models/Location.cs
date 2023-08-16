using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Shared.Models
{
	public record Location
	{
		[Required]
		public string? CountryCode { get; set; }

		public string? StateCode { get; set; }

		[Required]
		public string? City { get; set; }
		
		public double? Latitude { get; set; }

		public double? Longitude { get; set; }

		public Location() { }

		public Location(string? countryCode, string? stateCode, string? city, double? latitude, double? longitude)
		{
			CountryCode = countryCode;
			StateCode = stateCode;
			City = city;
			Latitude = latitude;
			Longitude = longitude;
		}

		public Location(string? countryCode, string? city, double? latitude, double? longitude)
		{
			CountryCode = countryCode;
			City = city;
			Latitude = latitude;
			Longitude = longitude;
		}
	}
}
