using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueRestClient
{
    internal class EnumStringProvider<T>
    {
        private static readonly ConcurrentDictionary<T, string> EnumToStringMap = new();

        public static string GetString(T t)
        {
            if (EnumToStringMap.TryGetValue(t, out string value))
            {
                return value;
            }

            string s = t.ToString();
            EnumToStringMap.TryAdd(t, s);

            return s;
        }
    }
}
