using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueRestClient
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
        DIAMOND,
        MASTER,
        GRANDMASTER,
        CHALLENGER
    }

    public enum Division
    {
        I,
        II,
        III,
        IV
    }
}
