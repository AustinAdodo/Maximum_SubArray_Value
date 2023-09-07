﻿using System;
using System.Collections.Generic;
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
        /// <param name="friendsNodes"></param>
        /// <param name="friendsFrom"></param>
        /// <param name="friendsTo"></param>
        /// <param name="friendsWeight"></param>
        /// <returns></returns>
        public static int maxShared(int friendsNodes, List<int> friendsFrom, List<int> friendsTo, List<int> friendsWeight)
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
    }
}

