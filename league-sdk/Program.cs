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
            Task<List<LeagueEntryDTO>> leagueEntriesResponse = leagueClient.GetLeagueEntries(Region.NA1, Queue.RANKED_SOLO_5x5, Tier.SILVER, Division.II, 1);
            leagueEntriesResponse.Wait();
            var encryptedSummonerId = leagueEntriesResponse.Result[0].SummonerId;

            Task<List<LeagueEntryDTO>> leagueEntryResponse = leagueClient.GetLeagueEntries(Region.NA1, encryptedSummonerId);
            leagueEntryResponse.Wait();
            Console.WriteLine(leagueEntryResponse.Result[0].SummonerId);

            Task<LeagueListDTO> challengerLeagueResponse = leagueClient.GetChallengerLeague(Region.NA1, Queue.RANKED_SOLO_5x5);
            challengerLeagueResponse.Wait();
            //Console.WriteLine(challengerLeagueResponse.Result.Queue);


        }
    }
}
