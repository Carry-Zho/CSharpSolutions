using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Code_TestJSONPath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonContent = File.ReadAllText("JSON.json");

            JArray jar = JsonConvert.DeserializeObject<JArray>(jsonContent)!;
            
            //列举具有“Name”属性的人员
            string jsonPath = "$..[?(@.Name)]";

            //var results = ((JContainer)jar).Descendants()
            //    .OfType<JObject>()
            //    .Where(obj => obj["Name"]?.ToString().StartsWith("张") ?? false);

            var results = from token in jar.Descendants()
                          where token is JObject job && (job["Name"]?.ToString().StartsWith("张") ?? false)
                          select token;

            foreach (var token in results)
            {
                Console.WriteLine(token);
            }
        }
    }
}
