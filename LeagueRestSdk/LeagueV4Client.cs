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
        private static readonly string LeagueV4Endpoint = Constants.LolEndpoint + "league/v4/";
        private static readonly string GetLeagueEntriesUrl = LeagueV4Endpoint + "entries/{1}/{2}/{3}?page={4}";
        private static readonly string GetLeagueEntriesBySummonerIdUrl = LeagueV4Endpoint + "entries/by-summoner/{1}";
        private static readonly string GetChallengerLeaguesUrl = LeagueV4Endpoint + "challengerleagues/by-queue/{1}";

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
            if (tier == Tier.CHALLENGER || tier == Tier.GRANDMASTER || tier == Tier.MASTER)
            {
                throw new ArgumentException("GetLeagueEntries does not support challenger, grandmaster or master tiers.");
            }

            string url = String.Format(
                GetLeagueEntriesUrl, 
                EnumStringProvider<Region>.GetString(region),
                EnumStringProvider<Queue>.GetString(queue),
                EnumStringProvider<Tier>.GetString(tier),
                EnumStringProvider<Division>.GetString(division),
                page);

            return await ProcessRequest<List<LeagueEntryDTO>>(url);
        }

        public async Task<List<LeagueEntryDTO>> GetLeagueEntries(Region region, string encryptedSummonerId)
        {
            string url = String.Format(
                GetLeagueEntriesBySummonerIdUrl,
                EnumStringProvider<Region>.GetString(region),
                encryptedSummonerId);

            return await ProcessRequest<List<LeagueEntryDTO>>(url);
        }

        public async Task<LeagueListDTO> GetChallengerLeague(Region region, Queue queue)
        {
            string url = String.Format(
                GetChallengerLeaguesUrl,
                EnumStringProvider<Region>.GetString(region),
                EnumStringProvider<Queue>.GetString(queue));

            return await ProcessRequest<LeagueListDTO>(url);
        }

        private async Task<T> ProcessRequest<T>(string url)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            requestMessage.Headers.Add(Constants.Headers.ApiKey, this.ApiKey);

            HttpResponseMessage responseMessage = await Client.SendAsync(requestMessage);
            string json = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(json);
            return JsonSerializer.Deserialize<T>(json, options: JsonOptions);
        }
    }
}
