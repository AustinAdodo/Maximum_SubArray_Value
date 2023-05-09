using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_SubArray_Value
{

    public class Aus1
    {
        public static int findLIS(int[] s)
        {
            if (s.Length < 2) return s.Length;
            bool isIncreasing = s.Zip(s.Skip(1), (a, b) => b > a).All(x => x);
            bool allEqual = s.All(x => x == s[0]);
            if (s.Length == 2 && isIncreasing) return 2;
            if (allEqual) return 1;
            List<List<int>> result = new List<List<int>>();
            List<int> ans = new List<int>();
            //collapse Array and create a LIst of lists
            for (int i = 0; i < s.Length; i++)
            {
                //populate
                result.Add(new List<int> { s[i] });
            }

            for (int i = 0; i < result.Count; i++)
            {
                List<int> temp = new List<int>();
                if (i + 1 <= s.Length - 1) { temp = s.Skip(i + 1).ToList(); }
                for (int j = 0; j < temp.Count; j++)
                {
                    if (temp[j] > result[i].Max()) result[i].Add(temp[j]);
                }
            }
            for (int i = 0; i < result.Count; i++)
            {
                ans.Add(result[i].Count);
            }
            return ans.Max();
        }
    }
}
