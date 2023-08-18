using System.Text.Json;
using System.Text.Json.Nodes;
using WeatherApp.Shared.Models;
using WeatherApp.Shared.OpenWeatherAPIParser;

namespace WeatherApp.Client.Services
{
	public class OpenWeatherParser
	{
		public List<Location> CitiesFromJson(string payload)
		{
			JsonNode payloadNode = JsonNode.Parse(payload);
			int nodeCount = payloadNode.AsArray().Count;
			List<Location> cities = new List<Location>();

			for (int i = 0; i < nodeCount; i++)
			{
				if (payloadNode[i] != null)
				{
					JsonNode currentNode = payloadNode[i];
					string city = currentNode!["name"]!.GetValue<string>();
					double latitude = currentNode!["lat"]!.GetValue<double>();
					double longitude = currentNode!["lon"]!.GetValue<double>();
					string country = currentNode!["country"]!.GetValue<string>();
					if (currentNode!["state"] != null)
					{
						string state = currentNode!["state"]!.GetValue<string>();
						Location location = new Location(country, state, city, latitude, longitude);
						cities.Add(location);
					}
					else 
					{
						Location location = new Location(country, city, latitude, longitude);
						cities.Add(location);
					}
				}
			}
			return cities;
		}


		public static Forecast ParseOneCallForecast(string payload)
		{
			JsonNode payloadNode = JsonNode.Parse(payload);

			// output components
			(double lat, double lon) = (payloadNode!["lat"]!.GetValue<double>(), payloadNode!["lon"]!.GetValue<double>());
			(string timezone, long timezoneOffset) = (payloadNode["timezone"].GetValue<string>(), payloadNode["timezone_offset"].GetValue<long>());
			ForecastCurrent currentForecast = ParseCurrentForecast(payloadNode["current"]);
			ForecastDaily[] dailyForecast = ParseDailyForecast(payloadNode["daily"]);
			ForecastCurrent[] hourlyForecast = ParseHourlyForecast(payloadNode["hourly"]);
			ForecastMinutely[] minutelyForecast = ParseMinutelyForecast(payloadNode!["minutely"]);

			// output
			Forecast outputForecast = new(
				timezone, timezoneOffset, lat, lon, currentForecast, dailyForecast, hourlyForecast, minutelyForecast
				);
			return outputForecast;
		}

		public static ForecastMinutely[] ParseMinutelyForecast(JsonNode minutelyNode)
		{
			return JsonSerializer.Deserialize<ForecastMinutely[]>(minutelyNode);
		}


		public static ForecastDaily[] ParseDailyForecast(JsonNode dailyNode)
		{
            int count = dailyNode.AsArray().Count;
            ForecastDaily[] output = new ForecastDaily[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = JsonSerializer.Deserialize<ForecastDaily>(dailyNode[i]);
            }
            return output;
		}

		public static ForecastCurrent ParseCurrentForecast(JsonNode node)
		{
			return JsonSerializer.Deserialize<ForecastCurrent>(node);
		}

		public static ForecastCurrent[] ParseHourlyForecast(JsonNode node)
		{
			int count = node.AsArray().Count;
			ForecastCurrent[] output = new ForecastCurrent[count];
			for (int i = 0; i < count; i++)
			{
				output[i] = ParseCurrentForecast(node[i]);
			}
			return output;
		}
	}
}
