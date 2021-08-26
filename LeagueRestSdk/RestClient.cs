using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LeagueRestClient
{

    public partial class RestClient
    {
        private static readonly HttpClient Client = new();

        private readonly string ApiKey;

        public RestClient(string apiKey)
        {
            this.ApiKey = apiKey;
        }
    }
}
