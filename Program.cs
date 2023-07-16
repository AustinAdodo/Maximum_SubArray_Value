
namespace Maximum_SubArray_Value
{
    public class Program
    {
        static void Main(string[] args)
        {
            //gggggggggggggggggggggggggggggg
            //9, 8, 7, 6, 5
            //int[] TestArr = { 1, 2, 1, 2, 1 }; //= 10
            //int[] TestArr = { 9, 8, 7, 6, 5 }; //=4
            //Console.Write(Aus.CountSawTooth(TestArr)); 
            //Console.Write(Aus.stringSplit("gggggggggggggggggggggggggggggg"));
            string[] arr = { "What", "must", "be", "shall", "be." };
            //string[] arr = { "This", "is", "an", "example", "of", "text", "justification." };
            Console.WriteLine(string.Join(",",Aus.FullJustify(arr,12)));
        }
    }
}

