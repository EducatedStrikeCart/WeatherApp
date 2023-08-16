using System.Text.Json;
using WeatherApp.Shared.Models;

namespace WeatherApp.Client.Services


{
	public class GeocoderService

	{
		private HttpClient _httpClient;

		public GeocoderService(HttpClient httpClient) { _httpClient = httpClient; }
		public async Task<Location[]> GetLocation(string cooardinates)
		{

			var response = await _httpClient.GetAsync("/geocoder/cities");
			string result = response.Content.ReadAsStringAsync().Result;
			Location[] locationArr = JsonSerializer.Deserialize<Location[]>(result);

			return locationArr;
		}
	}
}
