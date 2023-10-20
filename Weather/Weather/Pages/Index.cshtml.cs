using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Weather.Models;
using Weather.Service;

namespace Weather.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public MyWeather Weather { get; set; } = new();
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public async void OnPost() {
            WeatherService weatherService = new();
            var city = Request.Form["cityName"];
            var url = $"https://goweather.herokuapp.com/weather/{city}";
            var weatherData = weatherService.GetWeatherAsync(url);

            Weather = JsonSerializer.Deserialize<MyWeather>(weatherData.Result);
            Weather = await weatherService.SetImgPath(Weather);

        }
    }
}