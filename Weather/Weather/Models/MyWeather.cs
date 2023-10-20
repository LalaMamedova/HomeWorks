using System.Text.Json.Serialization;

namespace Weather.Models
{
    public class MyWeather
    {
        [JsonPropertyName("temperature")]
        public string Temperature { get; set; }

        [JsonPropertyName("wind")]
        public string Wind { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("forecast")]
        public Forecast[] Forecast { get; set; }
        public string ImgPath { get; set; } = "sunny.png";

        public override string ToString()
        {
            return $"{Temperature} {Wind} {Description} {ImgPath}";
        }
    }

    public class Forecast
    {
        [JsonPropertyName("day")]
        public string Day { get; set; }

        [JsonPropertyName("temperature")]
        public string Temperature { get; set; }

        [JsonPropertyName("wind")]
        public string Wind { get; set; }
    }
}
