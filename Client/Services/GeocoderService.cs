using System.Text.Json;
using WeatherApp.Shared.Models;

namespace WeatherApp.Client.Services


{
	public class GeocoderService

	{
		private HttpClient _httpClient;

		public GeocoderService(HttpClient httpClient) { _httpClient = httpClient; }
		public async Task<GeocoderResult[]> GetLocation(string cooardinates)
		{

			var response = await _httpClient.GetAsync("/geocoder/cities");
			string result = response.Content.ReadAsStringAsync().Result;
			GeocoderResult[] locationArr = JsonSerializer.Deserialize<GeocoderResult[]>(result);

			return locationArr;
		}
	}
}
