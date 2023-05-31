
namespace Maximum_SubArray_Value
{
    public class Program
    {
        static void Main(string[] args)
        {
            //int[] TestArr = { -2, -1, -4, 4, 7, 20, 1, 2, 5, -1, -4 };
            //Aus.Maximum_Subarray(TestArr);
            int[] arr1 = { 1, 4, 5, 2, 6 };
            int[] arr2 = { 6,8,9,11,12,19,22,23,35,67 };
            //Aus.FizzBuzz(15);
            int[] result = Aus1.ArrayMergeDifferentLengths(arr1,arr2);
            Console.Write(string.Join(",",result));

        }
    }
}

