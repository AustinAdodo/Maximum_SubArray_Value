using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Maximum_SubArray_Value
{
    public class Aus2
    {
        public static bool validatesomeString(string s)
        {
            int[] Num = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int b = 0;
            char[] words = new char[26];
            int index = 0;

            for (char letter = 'A'; letter <= 'Z'; letter++, index++)
            {
                words[index] = letter;
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

        static void Prob1(string[] args)
        {
            string months = Console.ReadLine();
            string[] arr = Array.ConvertAll(months.ToCharArray(), a => a.ToString());
            string[] check = { "J", "F", "M", "A", "M", "J", "J", "A", "S", "O", "N", "D" };
            if (arr[arr.Length - 1] == "D") Console.WriteLine("J");
            for (int i = 0; i < check.Length; i++)
            {
                if (check[i] == arr[0] && check[i + i] == arr[1]) Console.WriteLine(arr[3]);
                if (check[i] == "D") i = -1;
            }
        }

        static void camelCase(string s)
        {
            string[] st = Array.ConvertAll(s.ToCharArray(), s => s.ToString());
            List<string> alpha = new List<string>();
            for (char i = 'a'; i <= 'z'; i++)
            {

            }
            //return string.Join("",)
        }

        static void TupleSet(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int X = int.Parse(inputs[0]);
                int Y = int.Parse(inputs[1]);
                int Z = int.Parse(inputs[2]);
            }

            //156:5
            //846:6
            //313:3
            //292:2
            //666:6

            Console.WriteLine("answer");
        }

    }

    public class FileSearcher
    {
        public static string FileLocate(string directoryPath, string fileName)
        {
            string[] files = Directory.GetFiles(directoryPath, fileName, SearchOption.AllDirectories);

            if (files.Length > 0)
                return files[0];

            return null; // if file not found
        }

        public static void Main1()
        {
            string directoryPath = @"C:\Path\To\Search";
            string fileName = "odia";

            string filePath = FileLocate(directoryPath, fileName);

            if (filePath != null)
                Console.WriteLine($"File found: {filePath}");
            else
                Console.WriteLine("File not found.");
        }
    }

}

