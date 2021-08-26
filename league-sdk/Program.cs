using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeagueRestClient;

namespace league_sdk
{
    class Program
    {
        static void Main(string[] args)
        {
            var leagueClient = new LeagueRestClient.RestClient("RGAPI-42075eb2-3d66-4be6-9097-f0a8b4447e06");
            Task<List<LeagueEntryDTO>> response = leagueClient.GetLeagueEntries(Region.NA1, Queue.RANKED_SOLO_5x5, Tier.SILVER, Division.II, 1);

            response.Wait();

            Console.WriteLine(response.Result);
        }
    }
}
