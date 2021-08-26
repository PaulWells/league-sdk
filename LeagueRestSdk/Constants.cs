using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueRestClient
{
    internal class Constants
    {
        public class Headers
        {
            public static string ApiKey = "X-Riot-Token";
        }

        public static readonly string LolEndpoint = "https://{0}.api.riotgames.com/lol/";
    }
}
