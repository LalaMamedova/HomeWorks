using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using APIAsync.Class;
using System.Diagnostics;
using System.Net;

namespace APIAsync.Service
{
    public class DownLoadMovie
    {
        private HttpClient client = new();
        private static readonly string apiKey = @"7cfa399f03mshbf3facc1883df48p1d0453jsn25ecf857ed7b";
        private static readonly string apiUrl = @"https://imdb8.p.rapidapi.com/auto-complete?q=";


        public async Task Download(string title)
        {
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "imdb8.p.rapidapi.com");

            string requestUrl = apiUrl + title;

            var json = await client.GetStringAsync(requestUrl);
            var data = JsonConvert.DeserializeObject(json);
            var data2 = JsonConvert.DeserializeObject<MovieResult>(json);

            //MovieResult Movie = data as MovieResult;
            await Console.Out.WriteLineAsync(data2.ToString());
            //using (HttpResponseMessage response = await client.GetAsync(requestUrl))
            //{
            //    response.EnsureSuccessStatusCode();

            //    var res = await response.Content.ReadAsStringAsync();
            //    var data = JsonConvert.DeserializeObject(res);

            //    Console.WriteLine(data.ToString());

            //}
        }

    }
}
