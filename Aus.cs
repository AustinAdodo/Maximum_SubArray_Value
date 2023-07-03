using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_SubArray_Value
{
    public class Aus
    {
        //validate string contains only alpa number...

        public static bool validatesomeString(string s)
        {
            int[] Num = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int b = 0;
            char[] words = new char[26];
            int index = 0;

            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                words[index] = letter;
                index++;
            }
            string[] words1 = Array.ConvertAll(words, a => a.ToString());
            bool result = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (int.TryParse(s[i].ToString(), out b) == false) b = 11;
                if (!words1.Contains(s[i].ToString().ToLower()) && !Num.Contains(b)) { return false; }
                else { continue; }
            }
            return result;
        }
        public static void Maximum_Subarray(int[] arr)
        {
            Dictionary<int[], int> result = new Dictionary<int[], int>();
            //get aggregate of full array and gradually reduce aggregate map for each iteration.
            //j is Zero based so 1 must be added for a proper compensation.
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1; j < arr.Length; j++)
                {
                    int[] temp = arr.Skip(i).Take(j + 1).ToArray();
                    result[temp] = temp.Sum();
                }
            }
            int[] resultkey = result.Where(a => a.Value == result.Values.Max()).FirstOrDefault().Key;
            Console.Write("Subarray [{0}] has the Maximum value is {1}", string.Join(",", resultkey), result.Values.Max().ToString());
        }
        public static void FizzBuzz(int num)
        {
            string[] result = new string[num + 1];
            for (int i = 1; i <= num; i++)
            {
                if (i % 3 == 0 && i % 5 != 0) result[i] = "Fizz";
                if (i % 3 != 0 && i % 5 == 0) result[i] = "Buzz";
                if (i % 3 == 0 && i % 5 == 0) result[i] = "FizzBuzz";
                if (i % 3 != 0 && i % 5 != 0) result[i] = result[i] = i.ToString(); ;
            }
            Console.Write(string.Join(" ", result));
        }

        public static string RepeatedStrings(string s)
        {
            //"tuuuuuriiiiiing"
            //"tuuuriiing"
            string result = string.Empty;
            List<List<Tuple<string, int>>> counterList = new List<List<Tuple<string, int>>>();
            List<Tuple<string, int>> currentCounter = null;

            for (int i = 0; i < s.Length; i++)
            {
                if (i == 0 || s[i] != s[i - 1])
                {
                    currentCounter = new List<Tuple<string, int>>();
                    counterList.Add(currentCounter);
                }

                if (currentCounter.Count > 0)
                {
                    var last = currentCounter.Last();
                    currentCounter.RemoveAt(currentCounter.Count - 1);
                    currentCounter.Add(new Tuple<string, int>(last.Item1, last.Item2 + 1));
                }
                else
                {
                    currentCounter.Add(new Tuple<string, int>(s[i].ToString(), 1));
                }
            }

            foreach (var counter in counterList)
            {
                foreach (var tuple in counter)
                {
                    if (tuple.Item2 < 4) result += new string(char.Parse(tuple.Item1), tuple.Item2);
                    if (tuple.Item2 >= 4) result += new string(char.Parse(tuple.Item1), 3);
                }
            }
            return result.Trim();
        }

    }
}
