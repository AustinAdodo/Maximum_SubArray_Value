using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_SubArray_Value
{
    internal class AusMain
    {
        /// <summary>
        /// find the pairs with the maximum recurring interests.
        /// </summary>
        /// <param name="friendsNodes">Number of Participating Friends</param>
        /// <param name="friendsFrom">A Person with an interest</param>
        /// <param name="friendsTo"> A second Person with a shared interest</param>
        /// <param name="friendsWeight">Strength of a common interest</param>
        /// <returns>The maximum number of friends shared by any two people.</returns>
        public static int MaxShared(int friendsNodes, List<int> friendsFrom, List<int> friendsTo, List<int> friendsWeight)
        {
            Dictionary<Tuple<int, int>, int> resultSet = new();
            for (int i = 0; i < friendsFrom.Count; ++i)
            {
                Tuple<int, int> keyToCheck = Tuple.Create(friendsFrom[i], friendsTo[i]);
                if (resultSet.ContainsKey(keyToCheck))
                {
                    resultSet[keyToCheck]++;
                }
                else
                {
                    resultSet.Add(keyToCheck, 1);
                }
            }
            int maxValue = resultSet.Values.Max();
            IEnumerable<Tuple<int, int>> keysWithMaxValue = resultSet
              .Where(kv => kv.Value == maxValue)
              .Select(kv => kv.Key);
            List<int> arr = new List<int>();
            foreach (var key in keysWithMaxValue)
            {
                arr.Add(key.Item1 * key.Item2);
            }
            int[] arr2 = arr.Where(a => a == arr.Max()).ToArray();
            int p = arr2.Count();
            if (arr2.Count() > 1) return arr2.Sum();
            return arr2[0];
        }

        public static int maxCost(List<int> cost, List<string> labels, int dailyCount)
        {
            Dictionary<string, int> reg = new();
            List<int> ans = new List<int>();
            int target = 0;
            if (dailyCount >= labels.Count()) return cost.Sum();
            //bool condition = labels.Where(a => a == "legal").Count() == dailyCount;
            for (int i = 0; i < labels.Count; i++)
            {
                int deed = labels.GetRange(0, i+1).Where(a => a == "legal").Count();
                if (deed >0 && (deed % dailyCount == 0)) target=i;
            }
            for (int i = 0; i < target; ++i)
            {
                ans.Add(cost[i]);
            }
            return ans.Sum();
        }

        public static string Longest_recurring_substring(string s)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 1; i + j <= s.Length; j++)
                {
                    var subs = s.Substring(i, j);
                    if (dic.ContainsKey(subs)) dic[subs]++;
                    else { dic.Add(subs, 1); }
                }
            }
            var sortedDic = dic.OrderByDescending(pair => pair.Value)
                               .ThenBy(pair => pair.Key.Length)
                               .ToDictionary(pair => pair.Key, pair => pair.Value);

            var longestRecurringSubstring = sortedDic.FirstOrDefault();
            //Var longest_key_length = dic.Keys.Where(a => a.Length == dic.Keys.Max());
            return longestRecurringSubstring.Key;
           
        }
    }
}

