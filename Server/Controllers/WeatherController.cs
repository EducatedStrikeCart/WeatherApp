using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Shared.OpenWeatherAPIParser;

namespace WeatherApp.Server.Controllers
{
    [Route("api/v1/[controller]")]
	[ApiController]
	public class WeatherController : ControllerBase
	{
		private IConfiguration _configuration;
		private ILogger<WeatherController> _logger;
		private HttpClient _httpClient;

		public WeatherController(IConfiguration configuration, ILogger<WeatherController> logger, HttpClient httpClient)
		{
			_configuration = configuration;
			_logger = logger;
			_httpClient = httpClient;
		}

		//[HttpPost]
		//[Route("/forecast")]

		//public async Task<string> Forecast(Coordinates coordinates)
		//{
		//	var result = await _httpClient.PostAsJsonAsync<Coordinates>($"https://api.openweathermap.org/data/3.0/onecall?lat={coordinates.Latitude}lon={coordinates.Longitude}&units=imperial&appid={_configuration["OpenWeatherAPIKey"]}", coordinates);
		//	var payload = result.Content.ReadAsStringAsync().Result;
		//	return payload;
		//} 
	}
}
