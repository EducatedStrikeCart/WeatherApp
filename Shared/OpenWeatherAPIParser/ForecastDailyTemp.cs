using System.Text.Json.Serialization;

namespace WeatherApp.Shared.OpenWeatherAPIParser
{
    public class ForecastDailyTemp : IEquatable<ForecastDailyTemp?>
    { 
        // Day temperature 
        [JsonPropertyName("day")]
        public double Day { get; set; }
        // Min daily temperature.
        [JsonPropertyName("min")]
        public double Min { get; set; }

        // Max daily temperature.
        [JsonPropertyName("max")]
        public double Max { get; set; }

        //Night temperature
        [JsonPropertyName("night")]
        public double Night { get; set; }

        // Evening temperature.
        [JsonPropertyName("eve")]
        public double Eve { get; set; }

        // Morning temperature
        [JsonPropertyName("morn")]
        public double Morn { get; set; }

        public ForecastDailyTemp(double day, double min, double max, double night, double eve, double morn)
        {
            Day = day;
            Min = min;
            Max = max;
            Night = night;
            Eve = eve;
            Morn = morn;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ForecastDailyTemp);
        }

        public bool Equals(ForecastDailyTemp? other)
        {
            return other is not null &&
                   Day == other.Day &&
                   Min == other.Min &&
                   Max == other.Max &&
                   Night == other.Night &&
                   Eve == other.Eve &&
                   Morn == other.Morn;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Day, Min, Max, Night, Eve, Morn);
        }
    }
}