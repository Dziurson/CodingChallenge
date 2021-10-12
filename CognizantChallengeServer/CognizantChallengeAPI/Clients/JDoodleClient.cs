using CognizantChallengeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CognizantChallengeAPI.Clients
{
    public interface IJDoodleClient
    {
        public System.Threading.Tasks.Task Execute();
    }

    public class JDoodleClient : IJDoodleClient
    {
        private readonly HttpClient httpClient;

        public JDoodleClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async System.Threading.Tasks.Task Execute()
        {
            var request = new JDoodleExecuteRequest
            {
                ClientId = "95ca1659c6b66513b53c2bda98108c6b",
                ClientSecret = "c2933aeda030bd205ad626736c527e3e74408dd7fd4d2ad43b456a3dd0fbd4e1",
                Language = "csharp",
                Version = 3,
                Script = ""
            };

            var json = JsonSerializer.Serialize(request, options: new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            var response = await this.httpClient.PostAsync("execute", new StringContent(json, Encoding.UTF8, "application/json"));
            var a = response.Content.ReadAsStringAsync().Result;
            return;
        }
    }
}
