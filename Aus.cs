﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            string[] words = { "a", "b" };// a,b,c ,
            bool result = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (!words.Contains(s[i].ToString()) && !Num.Contains(int.Parse(s[i].ToString()))) { return false; }
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
    }
}
