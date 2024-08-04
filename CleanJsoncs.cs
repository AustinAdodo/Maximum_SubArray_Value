using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Maximum_SubArray_Value
{
    internal class CleanJsoncs
    {

        class MainClass
        {

            static Dictionary<string, object> FilterJsonElement(JsonElement element)
            {
                var filteredDict = new Dictionary<string, object>();
                foreach (var prop in element.EnumerateObject())
                {
                    var value = prop.Value;
                    switch (value.ValueKind)
                    {
                        case JsonValueKind.Object:
                            var subDict = FilterJsonElement(value);
                            if (subDict.Count > 0)
                            {
                                filteredDict[prop.Name] = subDict;
                            }
                            break;

                        case JsonValueKind.Array:
                            var filteredList = FilterJsonArray(value);
                            if (filteredList.Count > 0)
                            {
                                filteredDict[prop.Name] = filteredList;
                            }
                            break;


                        case JsonValueKind.String:
                            var stringValue = value.GetString();
                            if (stringValue != "-" && stringValue != "N/A" && stringValue != "")
                            {
                                filteredDict[prop.Name] = stringValue;
                            }
                            break;

                        case JsonValueKind.Number:
                            filteredDict[prop.Name] = value.GetDecimal();
                            break;

                        case JsonValueKind.True:
                        case JsonValueKind.False:
                            filteredDict[prop.Name] = value.GetBoolean();
                            break;

                        default:
                            break;
                    }
                }
                return filteredDict;
            }

            static List<object> FilterJsonArray(JsonElement array)
            {
                var filteredList = new List<object>();
                foreach (var item in array.EnumerateArray())
                {
                    switch (item.ValueKind)
                    {
                        case JsonValueKind.Object:
                            var subDict = FilterJsonElement(item);
                            if (subDict.Count > 0)
                            {
                                filteredList.Add(subDict);
                            }
                            break;

                        case JsonValueKind.Array:
                            var filteredSubArray = FilterJsonArray(item);
                            if (filteredSubArray.Count > 0)
                            {
                                filteredList.Add(filteredSubArray);
                            }
                            break;

                        case JsonValueKind.String:
                            var stringValue = item.GetString();
                            if (stringValue != "" && stringValue != "-" && stringValue != "N/A")
                            {
                                filteredList.Add(stringValue);
                            }
                            break;

                        case JsonValueKind.Number:
                            filteredList.Add(item.GetDecimal());
                            break;

                        case JsonValueKind.True:
                        case JsonValueKind.False:
                            filteredList.Add(item.GetBoolean());
                            break;

                        default:
                            break;

                    }
                }
                return filteredList;
            }

            static async Task CleanUp()
            {
                HttpClient client = new HttpClient();
                string s = await client.GetStringAsync("https://coderbyte.com/api/challenges/json/json-cleaning");

                using (JsonDocument doc = JsonDocument.Parse(s))
                {
                    var filteredDict = FilterJsonElement(doc.RootElement);
                    string result = JsonSerializer.Serialize(filteredDict,
                    new JsonSerializerOptions { WriteIndented = true });
                    Console.WriteLine(result);
                }
            }
        }
    }
}
