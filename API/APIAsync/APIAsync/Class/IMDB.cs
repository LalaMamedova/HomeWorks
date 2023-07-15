using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APIAsync.Class
{

    public class MovieResult
    {
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("paginationKey")]
        public string PaginationKey { get; set; }

        [JsonPropertyName("results")]
        public Result[] Results { get; set; }

        [JsonPropertyName("totalMatches")]
        public int TotalMatches { get; set; }

        public override string ToString()
        {
            return  Type + " " + PaginationKey;
        }


    }

    public class Meta
    {
        [JsonPropertyName("operation")]
        public string Operation { get; set; }

        [JsonPropertyName("requestId")]
        public string RequestId { get; set; }

        [JsonPropertyName("serviceTimeMs")]
        public float ServiceTimeMs { get; set; }

        public override string ToString()
        {
            return Operation + " " + RequestId + " "  + ServiceTimeMs;
        }
    }

    public class Result
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("image")]
        public Image Image { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("titleType")]
        public string TitleType { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("disambiguation")]
        public string Disambiguation { get; set; }

        public override string ToString()
        {
            return $"{Id} {Title} {TitleType} {Year}";
        }
    }

    public class Image
    {
        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }
    }


}
