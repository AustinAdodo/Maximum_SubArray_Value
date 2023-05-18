using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_SubArray_Value
{
    internal class Aus2
    {
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
