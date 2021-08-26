using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LeagueRestClient
{
    public partial class RestClient
    {
        private static readonly string LeagueV4Url = Constants.LolEndpoint + "league/v4/entries/{1}/{2}/{3}?page={4}";

        private static JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };

        public async Task<List<LeagueEntryDTO>> GetLeagueEntries(Region region, Queue queue, Tier tier, Division division, int page)
        {
            // Construct request
            string url = String.Format(
                LeagueV4Url, 
                EnumStringProvider<Region>.GetString(region),
                EnumStringProvider<Queue>.GetString(queue),
                EnumStringProvider<Tier>.GetString(tier),
                EnumStringProvider<Division>.GetString(division),
                page);

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            requestMessage.Headers.Add(Constants.Headers.ApiKey, this.ApiKey);

            // Send request
            HttpResponseMessage responseMessage = await Client.SendAsync(requestMessage);
            string json = await responseMessage.Content.ReadAsStringAsync();
            List<LeagueEntryDTO> response = JsonSerializer.Deserialize<List<LeagueEntryDTO>>(json, options: JsonOptions);
            
            return response;
        }
    }
}
