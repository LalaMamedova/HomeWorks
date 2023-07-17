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
    public class DownloadFact
    {
        private HttpClient client = new();
        private readonly string apiKey = "Pl5VYtZfu6eOz8ucB1JciWW9JT0T4OP1NjT7EBd7";
        private readonly string apiUrl = "https://api.api-ninjas.com/v1/facts?limit=";

        public async Task Download(int limit)
        {
            using (client)
            {
                client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

                HttpResponseMessage response = await client.GetAsync(apiUrl+limit);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<FactResult[]>(responseContent);
                    data.ToList().ForEach(fact =>
                    {
                        Console.WriteLine(fact);
                    });
                   
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode + " " + response.ReasonPhrase);
                }
            }
           
        }

     

    }
}
