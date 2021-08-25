using System;
using System.Threading.Tasks;
using League;

namespace league_sdk
{
    class Program
    {
        static void Main(string[] args)
        {
            var sdk = new LeagueRestSdk("RGAPI-2b6cd424-8b9c-4360-b662-d67f0570258d");
            Task<string> response = sdk.LeaugeV4(Region.NA1, Queue.RANKED_SOLO_5x5, Tier.SILVER, Division.II, 1);

            response.Wait();

            Console.WriteLine(response.Result);
        }
    }
}
