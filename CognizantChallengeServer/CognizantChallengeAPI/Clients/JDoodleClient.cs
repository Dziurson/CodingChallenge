using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CognizantChallengeAPI.Clients
{
    public interface IJDoodleClient
    {
        public void Execute();
    }

    public class JDoodleClient : IJDoodleClient
    {
        private readonly HttpClient httpClient;

        public JDoodleClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async void Execute()
        {
            var response = await this.httpClient.PostAsync("execute", new StringContent("", Encoding.UTF8, "application/json"));
            return;
        }
    }
}
