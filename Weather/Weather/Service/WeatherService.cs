using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using System.Collections.Generic;
using Weather.Models;

namespace Weather.Service
{
    public class WeatherService
    {
        public async  Task<MyWeather> SetImgPath(MyWeather weather)
        {

            Dictionary<string, string> weatherImages = new()
            {
                  { "rain", "rain.png" },
                  { "sun", "sunny.png" },
                  { "snow", "snowy.png" },
                  { "cloud", "clody.png" },
            };

            foreach (var kvp in weatherImages)
            {
                if (weather.Description.Contains(kvp.Key))
                {
                    weather.ImgPath = kvp.Value;
                    break;
                }
            }
            return weather;
        }

        public async Task<string> GetWeatherAsync(string url)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(method: HttpMethod.Get, url);
        
            using var response = client.SendAsync(request).Result;
            var body =  await response.Content.ReadAsStringAsync();
            return body;
        }
    }
}
