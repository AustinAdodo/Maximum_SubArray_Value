using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_SubArray_Value
{
    internal class AusMain
    {
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

    }
}

