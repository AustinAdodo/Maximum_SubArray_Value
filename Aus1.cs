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

        public static List<int> ArrayMergeDifferentLengths(int[] nums1, int[] nums2)
        {
            List<int> result = new List<int>();
            int nullablenum1 = 0;
            int nullablenum2 = 0;
            int limit = Math.Max(nums1.Length, nums2.Length);
            for (int i = 0; i < limit; i++)
            {
                nullablenum1 = (i >= 0 && i < nums1.Length) ? nums1[i] : 0;
                nullablenum2 = (i >= 0 && i < nums2.Length) ? nums2[i] : 0;
                result.Add(Math.Min(nullablenum1, nullablenum2));
                result.Add(Math.Max(nullablenum1, nullablenum2));
            }
            List<int> result1 = result.Where(a => a > 0).ToList();
            return result1;
        }

        public static string SpatialArrangement(string SampleString)
        {
            string[] temp = Array.ConvertAll(SampleString.ToCharArray(), s => s.ToString());
            List<string> Alpha = new List<string>();
            int x = 0;
            for (char i = 'a'; i <= 'z'; i++)
            {
                Alpha.Add(i.ToString());
            }
            for (int i = 0; i < 26; i++)
            {
                Alpha.Add(Alpha[i].ToUpper());
            }
            String[] hold = temp.Where(a => Alpha.Contains(a)).ToArray();
            string hold1 = string.Join("", hold.Reverse());
            for (int i = 0; i < hold1.Length; i++, x++)
            {
                if (Alpha.Contains(temp[x])) temp[x] = hold1[i].ToString();
                if (!Alpha.Contains(temp[x])) { i--; continue; }
            }
            string result = string.Join("", temp);
            return result;
        }
    }
}
