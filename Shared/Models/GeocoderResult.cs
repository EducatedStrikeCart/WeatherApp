using System.Text.Json.Serialization;

namespace WeatherApp.Shared.Models
{
	public class GeocoderResult
	{
		[JsonPropertyName("name")]
		public string Name;

		[JsonPropertyName("local_name")]
		public string[] LocalNames;

		[JsonPropertyName("lat")]
		public double Latitude;

		[JsonPropertyName("lon")]
		public double Longitude;

		[JsonPropertyName("country")]
		public string CountryCode;

		public GeocoderResult(string name, string[] localNames, double latitude, double longitude, string countryCode)
		{
			Name = name;
			LocalNames = localNames;
			Latitude = latitude;
			Longitude = longitude;
			CountryCode = countryCode;
		}

		public override bool Equals(object? obj)
		{
			return Equals(obj as GeocoderResult);
		}

		public bool Equals(GeocoderResult? other)
		{
			return other is not null &&
				   Name == other.Name &&
				   EqualityComparer<string[]>.Default.Equals(LocalNames, other.LocalNames) &&
				   Latitude == other.Latitude &&
				   Longitude == other.Longitude &&
				   CountryCode == other.CountryCode;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Name, LocalNames, Latitude, Longitude, CountryCode);
		}


	}
}
