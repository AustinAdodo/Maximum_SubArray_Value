using System.Collections.Immutable;
using System.Text.Json;

namespace Maximum_SubArray_Value
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //gggggggggggggggggggggggggggggg
            //9, 8, 7, 6, 5
            //int[] TestArr = { 1, 2, 1, 2, 1 }; //= 10
            //int[] TestArr = { 9, 8, 7, 6, 5 }; //=4
            int[] concerned = { 1, 1, 0, 0, 0, 0 };
            //int[] concerned = { 1, 0, 0, 0, 0, 0,1 };
            string[] arr101 = { "What", "must", "be", "shall", "be." };
            string[] arr102 = { "This", "is", "an", "example", "of", "text", "justification." };
            int[] cost = { 2, 5, 3, 11, 1 };
            string[] labels = { "legal", "illegal", "legal", "illegal", "legal" };
            int dailyCount = 2;
            //Console.WriteLine(string.Join(",",Aus.FullJustify(arr,16)));
            //List<Tuple<string, int>> tups = new List<Tuple<string, int>>
            //{
            //    new Tuple<string, int>("Buck", 12),
            //    new Tuple<string, int>("Luck", 10),
            //    new Tuple<string, int>("Duck", 3),
            //    new Tuple<string, int>("Ruck", 6),
            //    new Tuple<string, int>("Durk", 16),
            //    new Tuple<string, int>("Shock", 12)
            //};
            //var condition = tups.GroupBy(a => a).Any(group => group.Count() >= 2);
            //var axe = tups.GroupBy(a => a.Item2).OrderBy(a => a.Key);
            //if (condition) Console.Write(string.Join(",", tups.OrderBy(a => a.Item2).ThenBy(a => a.Item1).ToList()));
            //else { Console.Write(string.Join(",", tups.OrderBy(a => a.Item2))); }
            //Console.Write("\n");
            //Console.WriteLine(string.Join(" ",Aus1.Rep("11","9")));
            //bool result = concerned.Zip(concerned.Skip(1), (a, b) =>
            //Math.Abs(concerned.ToList().IndexOf(a) - concerned.ToList().IndexOf(b)) == 1).Any(a => a);
            ////Console.Write(result);

            //Console.WriteLine(AusMain.MaxShared(4,arr1.ToList(),arr2.ToList(),weight.ToList()));

            //Console.WriteLine(string.Join("\n", Aus.ChunkIter("Brethen_Bread",4)));

            var url = "https://coderbyte.com/api/challenges/json/json-cleaning";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();

            // Define a variable with the name "varOcg"
            var varOcg = true;

            // Deserialize the JSON response into CleanUpClass
            var cleanUpClass = JsonSerializer.Deserialize<CleanUpClass>(responseContent);

            // Clean up the object according to the rules
            cleanUpClass.Clean();

            // Serialize the modified object to a string and print it
            var modifiedJson = JsonSerializer.Serialize(cleanUpClass);
            Console.WriteLine(modifiedJson);
        }
    }
}

