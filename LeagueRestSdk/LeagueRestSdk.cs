using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace League
{
    public enum Region
    {
        BR1,
        EUN1,
        EUW1,
        JP1,
        KR,
        LA1,
        LA2,
        NA1,
        OC1,
        RU,
        TR1
    }

    public enum Queue
    {
        RANKED_FLEX_SR,
        RANKED_SOLO_5x5,
        RANKED_FLEX_TT
    }

    public enum Tier
    {
        IRON,
        BRONZE,
        SILVER,
        GOLD,
        PLATINUM,
        DIAMOND
    }

    public enum Division
    {
        I,
        II,
        III,
        IV
    }

    internal class Headers
    {
        public static string ApiKey = "X-Riot-Token";
    }

    public class LeagueRestSdk
    {
        private static readonly HttpClient Client = new();
        private static string LolEndpoint = "https://{0}.api.riotgames.com/lol/";

        private static string LeagueV4Url = LolEndpoint + "league/v4/entries/{1}/{2}/{3}?page={4}";

        private string ApiKey;

        public LeagueRestSdk(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        public async Task<string> LeaugeV4(Region region, Queue queue, Tier tier, Division division, int page)
        {
            // TODO: cache enum ToString results
            string url = String.Format(LeagueV4Url, region.ToString(), queue.ToString(), tier.ToString(), division.ToString(), page);

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            requestMessage.Headers.Add(Headers.ApiKey, this.ApiKey);

            HttpResponseMessage responseMessage = await Client.SendAsync(requestMessage);

            string response = await responseMessage.Content.ReadAsStringAsync();

            // TODO: parse into LeagueV4Response object

            return response;
        }
    }
}
