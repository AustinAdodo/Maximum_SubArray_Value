using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Data;
using System.Security;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Maximum_SubArray_Value
{
    public class Aus
    {
        //bool isIncreasing = s.Zip(s.Skip(1), (a, b) => b > a).All(x => x);
        //validate string contains only alpa number...
        //dynamic programming
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

        //Applied Tuples and using tuples to handle numerous data types where uniqu values arent intended.
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
            return string.Join("", s.Select((a, i) => i == 0 || (i > 0 && s[i - 1].ToString() == "_") ? a.ToString().ToUpper() : a.ToString())
                .Where(a => alpha.Contains(a.ToLower())));
        }

        //CamelCase
        public static void camelCase(string s)
        {
            string[] st = Array.ConvertAll(s.ToCharArray(), s => s.ToString());
            List<string> alpha = new List<string>();
            for (char i = 'a'; i <= 'z'; i++)
            {

            }
            //return string.Join("",)
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

        //
        //Assume all bills are always available 1000, dic[50] += (amount % 100) / 50;
        public static List<int> Withdraw(int amount)
        {
            List<int> result = new List<int>();
            Dictionary<int, int> dic = new Dictionary<int, int>() { { 100, 0 }, { 50, 0 }, { 20, 0 } };
            if (amount >= 100) { dic[100] += amount / 100; amount %= 100; }
            if (amount >= 50 && amount < 100) { dic[50] += (amount / 50); amount %= 50; }
            if (amount < 50 && amount > 0) { dic[20] += (amount / 20); amount %= 20; }
            //check if theres a remainder at the end.
            if (amount != 0 && dic[50] > 0)
            {
                dic[50]--; dic[20] = (50 + amount + (dic[20]) * 20) / 20;
                foreach (var item in dic)
                {
                    result.Add(item.Value);
                }
                return result;
            }
            if (amount != 0 && dic[50] == 0)
            {
                dic[100]--; dic[50]++; dic[20] = (50 + amount + (dic[20]) * 20) / 20;
                foreach (var item in dic)
                {
                    result.Add(item.Value);

                }
                return result;
            }
            foreach (var item in dic)
            {
                result.Add(item.Value);
            }
            return result;
        }

        //complex chunks Methond method

        public static IEnumerable<string> ChunkIter2(string s, int chunks)
        {
            int[] arr2 = new int[chunks]; int p = 0;
            int chunker = chunks;
            int[] store = new int[chunks];
            List<string> result = new List<string>();
            if (s.Length > 0 && s.Length <= chunks) return s.Select(c => c.ToString()); ;
            if (s.Length > 0 && chunks == 0) throw new ArgumentException();
            if (s.Length == 0 && chunks >= 0) return Array.Empty<string>();
            int premium = s.Length;

            for (int i = 0; i < arr2.Length; i++)
            {
                result.Add(s.Substring(p, arr2[i]));
                p += arr2[i];
            }
            return result;
        }

        //Complex Chunks first method
        public static IEnumerable<string> ChunkIter(string s, int chunks)
        {
            string[] arr = Array.ConvertAll(s.ToCharArray(), c => c.ToString());
            int[] arr2 = new int[chunks]; int p = 0;
            List<string> result = new List<string>();
            if (s.Length > 0 && s.Length <= chunks) return arr;
            if (s.Length > 0 && chunks == 0) throw new ArgumentException();
            if (s.Length == 0 && chunks >= 0) return Array.Empty<string>();
            if (s.Length > 0 && s.Length > chunks)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    int b = (s.Length - i > chunks) ? chunks : s.Length - i;
                    for (int j = 0; j < b; j++)
                    {
                        arr2[j]++;
                    }
                    i += (s.Length - i > chunks) ? chunks - 1 : s.Length - i;
                }
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                result.Add(s.Substring(p, arr2[i]));
                p += arr2[i];
            }
            return result;
        }

        public static string[] Chunk(string s, int chunks)
        {
            List<string> result = new List<string>();
            result = ChunkIter(s, chunks).ToList();
            return result.ToArray();
        }

        public static int[] ArrangeNums(int[] k)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < k.Length; i++)
            {
                //Math.Abs()
            }
            List<int> result = new List<int>();

            foreach (var kvp in dic)
            {
                int key = kvp.Key;
                int value = kvp.Value;

                result.AddRange(Enumerable.Repeat(key, value));
            }
            return result.ToArray();
        }

        public static bool IsSawToothArr(int[] arr)
        {
            //bool result = false;    
            if (arr.Length > 1 && arr[0] < arr[1])
            {
                //LinkedHashMap
                //OrderedDictionary linkedHashMap = new OrderedDictionary();
                //if (arr.Length == 2) return true;
                for (int i = 1; i < arr.Length; i += 2)
                {
                    if (arr.Length == 2) return true;
                    if (i + 1 <= arr.Length - 1 && arr[i - 1] < arr[i] && arr[i] > arr[i + 1]
                        || i == arr.Length - 1 && arr[i] > arr[i - 1]) continue;
                    return false;
                }
                return true;
            }

            if (arr.Length > 1 && arr[0] > arr[1])
            {
                //if (arr.Length == 2) return true;
                for (int i = 1; i < arr.Length; i += 2)
                {
                    if (arr.Length == 2) return true;
                    if (i + 1 <= arr.Length - 1 && arr[i - 1] > arr[i] && arr[i] < arr[i + 1]
                        || i == arr.Length - 1 && arr[i] < arr[i - 1]) continue;
                    return false;
                }
                return true;
            }
            return false;
        }

        //Taking Only Contigious Sub Arrays.
        public static long CountSawTooth(int[] arr)
        {
            int ans = 0;
            if (arr.All(a => a == arr[0])) return 0;
            //new ArrayEqualityComparer()
            HashSet<int[]> result = new HashSet<int[]>();

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1; i + j <= arr.Length; j++)
                {
                    int[] temp = arr.Skip(i).Take(j).ToArray();
                    result.Add(temp);
                }
            }

            //result.Add(arr);
            foreach (var kvp in result)
            {
                if (IsSawToothArr(kvp)) ans++;
            }
            return ans;
        }

        public class ArrayEqualityComparer : IEqualityComparer<int[]>
        {
            public bool Equals(int[] x, int[] y)
            {
                if (ReferenceEquals(x, y))
                    return true;

                if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                    return false;

                if (x.Length != y.Length)
                    return false;

                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] != y[i])
                        return false;
                }

                return true;
            }

            public int GetHashCode(int[] obj)
            {
                if (ReferenceEquals(obj, null))
                    return 0;

                int hashCode = 17;

                foreach (int item in obj)
                {
                    hashCode = hashCode * 31 + item.GetHashCode();
                }

                return hashCode;
            }
        }

        public static int stringSplit(string s)
        {
            int ans = 0;
            List<Tuple<string, string, string>> result = new List<Tuple<string, string, string>>();
            foreach (var item in result)
            {

            }
            int l = s.Length;
            return ans;
        }

        //Test Alignment algo
        public static IList<string> FullJustify(string[] words, int maxWidth)
        {
            List<List<string>> stacks = new List<List<string>>();
            List<string> ans = new List<string>();
            List<string> temp = new List<string>();
            for (int i = 0; i < words.Length; ++i)
            {
                if (temp.Count == 0 && i < words.Length - 1) { temp.Add(words[i]); continue; }

                if ((string.Join(" ", temp) + " " + words[i]).Length < maxWidth && i < words.Length - 1)
                { string s = string.Join(" ", temp) + " " + words[i]; temp.Clear(); temp.Add(s); continue; }

                if ((string.Join(" ", temp) + " " + words[i]).Length == maxWidth)
                {
                    string s = string.Join(" ", temp) + " " + words[i]; temp.Clear(); temp.Add(s);
                    stacks.Add(new List<string> { string.Join(" ", temp) }); continue;
                }

                if ((string.Join(" ", temp) + " " + words[i]).Length > maxWidth)
                { stacks.Add(new List<string> { string.Join(" ", temp) }); temp.Clear(); i--; continue; }

                else { temp.Add(words[i]); stacks.Add(temp); break; }
            }
            foreach (List<string> item in stacks)
            {
                string[] sub = string.Join(" ", item).Split(" ");
                if (sub.Length > 1)
                {
                    //Add Spaces in chunks
                    int diff = maxWidth - string.Join(" ", item).Length;
                    for (int i = 0; i < sub.Length && diff > 0; ++i)
                    {
                        if (i < sub.Length - 1) { sub[i] = sub[i] + " "; diff--; }
                        if (i == sub.Length - 1 && diff > 0) i = -1;
                    }
                }
                else
                {
                    int diff = maxWidth - sub[0].Length;
                    sub[0] = sub[0] + new string(' ', diff);
                }
                //while (diff > 0) { sub.Select(a => (sub.ToList().IndexOf(a) < sub.Length - 1) ? a + " " : a).ToList(); diff -= sub.Length; }
                ans.Add(string.Join(" ", sub));
            }
            return ans;
        }
        static bool HasDuplicatesInSecondColumn(List<List<string>> twoDList)
        {
            IEnumerable<string> secondColumnValues = twoDList.Select(row => row[1]);
            bool hasDuplicates = secondColumnValues.GroupBy(value => value)
                                                  .Any(group => group.Count() > 1);

            return hasDuplicates;
        }

        public static bool IsValid(string s)
        {
            Dictionary<char, char> opcl = new Dictionary<char, char>
        {
            { '(', ')' },
            { '[', ']' },
            { '{' , '}' }
        };
            Stack<char> stack = new Stack<char>();
            foreach (char i in s)
            {
                if (i == '(' || i == '[' || i == '{') stack.Push(i);
                else if (stack.Count == 0 || i != opcl[stack.Pop()]) return false;
            }
            return stack.Count == 0;
        }

        public async static void Quest()
        {
            HttpClient client = new HttpClient();
            string uri = "https://coderbyte.com/api/challenges/json/age-counting";
            HttpResponseMessage response = await client.GetAsync(uri);
            string s = await response.Content.ReadAsStringAsync();
            JObject jsonObject = JObject.Parse(s);
            string dataValue = jsonObject["data"].ToString();
            string[] Pairs = dataValue.Split(',');
            int count = 0;

            foreach (string kvp in Pairs)
            {
                string[] parts = kvp.Trim().Split('=');

                if (parts.Length == 2 && parts[0].Trim() == "age")
                {
                    // Parse the age value as an integer and check if it's greater than 50
                    if (int.TryParse(parts[1].Trim(), out int age) && age >= 50)
                    {
                        count++;
                    }
                }
            }
            string ans = "hvblwq79c1";
            ans = string.Join("", ans.Select((i, ele) => i + 1 % 3 == 0 ? 'X' : ele));
            Console.WriteLine($"{ans}");
        }

        public static async Task<string> retrieve()
        {
            HttpClient client = new HttpClient();
            string uri = "https://coderbyte.com/api/challenges/json/age-counting";
            //string s = client.DownloadString();
            HttpResponseMessage response = await client.GetAsync(uri);
            string s = await response.Content.ReadAsStringAsync();
            return s;
        }
        public static void Quest1()
        {
            //string jsonResponse = "{\"data\":\"key=IAfpK, age=2, key=WNVdi, age=1, key=jp9zt, age=47, key=jp9zt, age=1\"}";
            string s = retrieve().Result;
            JObject obj = JObject.Parse(s);
            string data = obj["data"].ToString();
            //data = data.Replace(", age=1", "");
            string[] arr = data.Split(", ");
            int count = 0;
            int i = 0;
            foreach (string item in arr)
            {
                if (i > 0 && item.StartsWith("age=") && item.Contains("age=1"))
                {
                    arr[i] = "pass";
                    arr[i - 1] = "pass";
                }
                ++i;
            }
            i = 0;
            count = arr.Where(a => a != "pass").Count();

            Console.WriteLine($"{count / 2}");
        }

        //Retrieve Logs Fom API
        static async Task<string> GetLogsAsync(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        //Retrive Unique Ids from the Getlogs
        static List<string> ExtractUniqueIds(string logs)
        {
            List<string> ids = new List<string>();
            Dictionary<string, int> idCount = new Dictionary<string, int>();
            // Regular expression pattern to match the IDs
            string pattern = @"\?shareLinkId=(\w+)";
            MatchCollection matches = Regex.Matches(logs, pattern);

            foreach (Match match in matches)
            {
                string id = match.Groups[1].Value;
                if (idCount.ContainsKey(id))
                {
                    idCount[id]++;
                }
                else
                {
                    idCount[id] = 1;
                    ids.Add(id);
                }
            }
            // Append :N to IDs that appear more than once
            for (int i = 0; i < ids.Count; i++)
            {
                if (idCount[ids[i]] > 1)
                {
                    ids[i] = $"{ids[i]}:{idCount[ids[i]]}";
                }
            }
            return ids;
        }
        public static async void Quest2(string[] args)
        {
            try
            {
                string logsUrl = "https://coderbyte.com/api/challenges/logs/web-logs-raw";
                string logs = await GetLogsAsync(logsUrl);

                List<string> uniqueIds = ExtractUniqueIds(logs);

                foreach (var id in uniqueIds)
                {
                    Console.WriteLine(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }
}

