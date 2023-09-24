using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_SubArray_Value
{
    internal class Binary_Check
    {
        public static bool IsBinaryFile(string filePath)
        {
            try
            {
                using (FileStream file = File.OpenRead(filePath))
                {
                    byte[] chunk = new byte[1024];
                    int bytesRead = file.Read(chunk, 0, chunk.Length);
                    while (bytesRead > 0)
                    {
                        // Check for null bytes or non-printable characters
                        if (chunk.ToString().Contains("b'\x00'") || chunk.Any(Byte => Byte < 32 && Byte != 9 && Byte != 10 && Byte != 13))
                        {
                            return true; // Binary file
                        }
                        bytesRead = file.Read(chunk, 0, chunk.Length);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                throw new Exception(e.Message);
            }
            //catch (PermissionException e)
            //{
            //    throw new Exception(e.Message);
            //}
            //catch (ProcessLookupException e)
            //{
            //    throw new Exception(e.Message);
            //}
            return false;
        }

        public static string ToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public static string FromBinary(string binary)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < binary.Length; i += 8)
            {
                char c = Convert.ToChar(Convert.ToInt32(binary.Substring(i, 8), 2));
                sb.Append(c);
            }
            return sb.ToString();
        }

    }
}
