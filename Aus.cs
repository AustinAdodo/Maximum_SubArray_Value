﻿using System;
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
            string result = String.Empty;
            List<Tuple<string, int>> counter = new List<Tuple<string, int>>();

            for (int i = 0; i < s.Length; i++)
            {
                if (counter.Count == 0 || s[i] != s[i - 1])
                {
                    counter.Add(new Tuple<string, int>(s[i].ToString(), 1));
                }
                else
                {
                    int temp = counter.Last().Item2;
                    counter.RemoveAt(counter.Count - 1);
                    counter.Add(new Tuple<string, int>(s[i].ToString(), temp + 1));
                }
            }
            foreach (var tuple in counter)
            {
                if (tuple.Item2 < 4) result += new string(char.Parse(tuple.Item1), tuple.Item2);
                if (tuple.Item2 >= 4) result += new string(char.Parse(tuple.Item1), 3);
            }
            return result.Trim();
        }
        public static string Capitalize(string s)
        {
            List<string> alpha = new List<string>();
            for (char i = 'a'; i <= 'z'; i++)
            {
                alpha.Add(i.ToString());
            }
            string[] ss = Array.ConvertAll(s.ToCharArray(), s => s.ToString());
            return string.Join("", ss.Select((a, i) => i == 0 || (i > 0 && ss[i - 1] == "_") ? a.ToUpper() : a.ToString())
                .Where(a => alpha.Contains(a.ToLower())));
        }
        static int LongestSubstring(string s)
        {
            int Maxvalue = 0; int shift = 0; int count = 0;
            Dictionary<char, int> result = new Dictionary<char, int>();
            if (s.All(a => a == s[0])) return 1;
            for (int i = 0; i < s.Length; i++)
            {
                if (result.ContainsKey(s[i])) { i = shift; shift++; count = result.Count; result.Clear(); }
                else { result.Add(s[i], 1); }
                if (count > Maxvalue) Maxvalue = count;
            }
            return Maxvalue;
        }
        public static string MostRequestedCharacterMethod1(string characters)
        {
            List<List<string>> results = new List<List<string>>();
            for (int i = 0; i < characters.Length; i++)
            {
                if (!results.Any(a => a[0].Contains(characters[i])))
                {
                    results.Add(new List<string>() { characters[i].ToString(), (characters.Split(characters[i]).Length - 1).ToString() });
                }
            }
            results.Sort((x, y) => int.Parse(x[1]).CompareTo(int.Parse(y[1])));
            results.Reverse();
            return results[0][0];
        }
    }
}
