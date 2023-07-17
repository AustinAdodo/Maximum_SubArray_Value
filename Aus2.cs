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
        public static bool ValidatesomeString(string s)
        {
            int[] Num = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };int b = 0;int index = 0;
            string[] words = new string[26];bool result = true;
            for (char letter = 'A'; letter <= 'Z'; letter++, index++) words[index] = letter.ToString();
            if (s.Any(a => !words.Contains(a.ToString().ToLower()) && int.TryParse(a.ToString(), out b) == false)) return false;
            return result;
        }
        //Midpoint
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

