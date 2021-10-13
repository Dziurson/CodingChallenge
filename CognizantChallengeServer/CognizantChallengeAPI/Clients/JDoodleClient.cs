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
        public Task<JDoodleExecuteResult> Execute(TaskSubmit taskSubmit);
    }

    public class JDoodleClient : IJDoodleClient
    {
        private readonly HttpClient httpClient;

        public JDoodleClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<JDoodleExecuteResult> Execute(TaskSubmit taskSubmit)
        {
            var request = new JDoodleExecuteRequest
            {
                ClientId = "95ca1659c6b66513b53c2bda98108c6b",
                ClientSecret = "c2933aeda030bd205ad626736c527e3e74408dd7fd4d2ad43b456a3dd0fbd4e1",
                Language = "csharp",
                Version = 1,
                Script = taskSubmit.Solution.Replace("\n", "\n\r")
            };

            var json = JsonSerializer.Serialize(request, options: new JsonSerializerOptions { 
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
            var response = await this.httpClient.PostAsync("execute", new StringContent(json, Encoding.UTF8, "application/json"));
            var resultJson = response.Content.ReadAsStringAsync().Result;
            
            if (response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<JDoodleExecuteResponse>(resultJson, options: new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                return new JDoodleExecuteResult
                {
                    Output = result.Output,
                    StatusCode = result.StatusCode
                };
            }
            else
            {
                var result = JsonSerializer.Deserialize<JDoodleExecuteErrorResponse>(resultJson);
                return new JDoodleExecuteResult
                {
                    Error = result.Error,
                    StatusCode = result.StatusCode
                };
            }
        }
    }
}
