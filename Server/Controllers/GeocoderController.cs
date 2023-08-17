using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WeatherApp.Client.Services;
using WeatherApp.Shared.Models;
using static System.Net.WebRequestMethods;

namespace WeatherApp.Server.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]

	public class GeocoderController : Controller
	{
		private IConfiguration _configuration;
		private HttpClient _httpClient;
		private ILogger<GeocoderController> _logger;

		public GeocoderController(IConfiguration configuration, HttpClient httpClient, ILogger<GeocoderController> logger)
		{
			_configuration = configuration;
			_httpClient = httpClient;
			_logger = logger;
		}

		[HttpPost]
		[Route("cities")]
		public async Task<string> GetCitiesJson(Location userLocation)
		{
			string optionalStateParam = userLocation.StateCode != null ? $",{userLocation.StateCode}" : ""; // Add in StateCode to query if needed
			var response = await _httpClient.GetAsync(
				$"http://api.openweathermap.org/geo/1.0/direct?q={userLocation.City}{optionalStateParam},{userLocation.CountryCode}&limit=5&appid={_configuration["OpenWeatherAPIKey"]}"
			);
			Console.Write($"http://api.openweathermap.org/geo/1.0/direct?q={userLocation.City}{optionalStateParam},{userLocation.CountryCode}&limit=5&appid={_configuration["OpenWeatherAPIKey"]}");
			string result = response.Content.ReadAsStringAsync().Result;
			return result;
		}

		[HttpGet]
		[Route("test")]
		public string Test()
		{
			_logger.LogDebug("Test Log  Message");
			return "hi";
		}
	}
}

