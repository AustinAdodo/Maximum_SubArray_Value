
namespace Maximum_SubArray_Value
{
    public class Program
    {
        static void Main(string[] args)
        {
            //int[] TestArr = { -2, -1, -4, 4, 7, 20, 1, 2, 5, -1, -4 };
            //Aus.Maximum_Subarray(TestArr);
            //int[] arr = { 1, 4, 5, 2, 6 };
            //int[] arr1 = { 2,2,2,2,2 };
            string s = "ABCDE";
            string result = String.Empty;
            for (int i = s.Length; i-- > 0;)
            {
                result += s[i].ToString();
            }
            Console.WriteLine(result);
            Console.Write(string.Join("",s.Reverse()));    
        }
    }
}

