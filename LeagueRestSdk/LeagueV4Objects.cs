using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueRestClient
{

    public class LeagueEntryDTO
    {
        public string LeagueId { get; set; }
        public string SummonerId { get; set; }
        public string SummonerName { get; set; }
        public Queue QueueType { get; set; }
        public Tier Tier { get; set; }
        public Division Rank { get; set; }
        public int LeaguePoints { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public bool HotStreak { get; set; }
        public bool Veteran { get; set; }
        public bool FreshBlood { get; set; }
        public bool Inactive { get; set; }
        public MiniSeriesDTO MiniSeries { get; set; }
    }

    public class MiniSeriesDTO
    {
        public int Losses { get; set; }
        public string Progress { get; set; }
        public string Target { get; set; }
        public string Wins { get; set; }
    }

    public class LeagueListDTO
    {
        public string LeagueId { get; set; }
        public List<LeagueItemDTO> Entries { get; set; }
        public Tier Tier { get; set; }
        public string Name { get; set; }
        public Queue Queue { get; set; }
    }

    public class LeagueItemDTO
    {
        public bool FreshBlood { get; set; }
        public int Wins { get; set; }
        public string SummonerName { get; set; }
        public MiniSeriesDTO MiniSeries { get; set; }
        public bool Inactive { get; set; }
        public bool Veteran { get; set; }
        public bool HotStreak { get; set; }
        public Division Rank { get; set; }
        public int LeaguePoints { get; set; }
        public int Losses { get; set; }
        public string SummonerId { get; set; }
    }

}
