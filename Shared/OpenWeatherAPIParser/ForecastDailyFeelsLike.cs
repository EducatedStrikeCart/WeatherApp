using System.Text.Json.Serialization;

namespace WeatherApp.Shared.OpenWeatherAPIParser
{
    public class ForecastDailyFeelsLike : IEquatable<ForecastDailyFeelsLike?>
    {
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

        public ForecastDailyFeelsLike(double day, double night, double eve, double morn
            )
        {
            Day = day;
            Night = night;
            Eve = eve;
            Morn = morn;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ForecastDailyFeelsLike);
        }

        public bool Equals(ForecastDailyFeelsLike? other)
        {
            return other is not null &&
                   Day == other.Day &&
                   Night == other.Night &&
                   Eve == other.Eve &&
                   Morn == other.Morn;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Day, Night, Eve, Morn);
        }
    }
}