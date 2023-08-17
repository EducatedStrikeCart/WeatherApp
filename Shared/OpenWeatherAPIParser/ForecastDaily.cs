using System.Text.Json.Serialization;

namespace WeatherApp.Shared.OpenWeatherAPIParser
{
    public class ForecastDaily : ForecastBasic
    {
        // The time of when the moon rises for this day, Unix, UTC
        [JsonPropertyName("moonrise")]
        public long Moonrise { get; set; }

        // The time of when the moon sets for this day, Unix, UTC
        [JsonPropertyName("moonset")]
        public long Moonset { get; set; }

        // Moon phase. 0 and 1 are 'new moon', 0.25 is 'first quarter moon', 0.5 is 'full moon' and 0.75 is 'last quarter moon'.
        [JsonPropertyName("moon_phase")]
        public double MoonPhase { get; set; }

        // Daily Temperature. Units – default: kelvin, metric: Celsius, imperial: Fahrenheit.
        [JsonPropertyName("temp")]
        public ForecastDailyTemp Temp { get; set; }

        // This accounts for the human perception of weather. Units – default: kelvin, metric: Celsius, imperial: Fahrenheit. How to change units used
        [JsonPropertyName("feels_like")]
        public ForecastDailyFeelsLike FeelsLike { get; set; }

        // Probability of precipitation. The values of the parameter vary between 0 and 1, where 0 is equal to 0%, 1 is equal to 100%
        [JsonPropertyName("pop")]
        public double? Pop { get; set; }

        public ForecastDaily(
            long dt,
            long? sunrise,
            long? sunset,
            long moonrise,
            long moonset,
            double moonPhase,
            ForecastDailyTemp temp,
            ForecastDailyFeelsLike feelsLike,
            long pressure,
            long humidity,
            double dewPoint,
            double windSpeed,
            double windDeg,
            double? windGust,
            ForecastWeather[] weather,
            long clouds,
            double uvi,
            double? pop,
            double? rain,
            double? snow) : base(dt, sunrise, sunset, pressure, humidity, dewPoint, uvi, clouds, windSpeed, windGust, windDeg, rain, snow, weather)
        {
            Moonrise = moonrise;
            Moonset = moonset;
            MoonPhase = moonPhase;
            Temp = temp;
            FeelsLike = feelsLike;
            Pop = pop;
        }
    }
}
