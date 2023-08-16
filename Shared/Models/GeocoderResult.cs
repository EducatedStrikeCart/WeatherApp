using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Shared.Models
{
	public record GeocoderResult
	{
		public string Name;
		public string[] LocalNames;
		public double Latitude;
		public double Longitude;
		public string CountryCode;
	}
}
