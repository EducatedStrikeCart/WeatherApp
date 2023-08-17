using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.Shared.OpenWeatherAPIParser
{
	public class ForecastWeather : IEquatable<ForecastWeather?>
    {
		// Weather condition id
		[JsonPropertyName("id")]
		public long Id { get; set; }

		// Group of weather parameters (Rain, Snow, Extreme etc.)
		[JsonPropertyName("main")]
		public string Main { get; set; }

		// Weather condition within the group
		[JsonPropertyName("description")]
		public string Description { get; set; }

		// Weather icon id
		[JsonPropertyName("icon")] // TODO: implement OpenWeather icons
		public string Icon { get; set; }

		public ForecastWeather(long id, string main, string description, string icon)
		{
			Id = id;
			Main = main;
			Description = description;
			Icon = icon;
		}

        public override bool Equals(object? obj)
        {
            return Equals(obj as ForecastWeather);
        }

        public bool Equals(ForecastWeather? other)
        {
            return other is not null &&
                   Id == other.Id &&
                   Main == other.Main &&
                   Description == other.Description &&
                   Icon == other.Icon;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Main, Description, Icon);
        }
    }
}
