using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Code_JContainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonFile = @"JSON.json";
            string jsonContent = File.ReadAllText(jsonFile);

            JContainer jct = (JContainer)JToken.Parse(jsonContent);

            Console.WriteLine($"Children tokens of the jct:{jct.Count}");

            jct.Merge(new JProperty("Timi", "Gaming now"));

            Console.WriteLine($"Children tokens of the JContainer after merging a JProperty:{jct.Count}");

            JObject job = new JObject
            {
                { "Name", "Timi" }
            };

            jct.Merge(job);
            Console.WriteLine($"Children tokens of the JContainer after merging a JObject that has an existing property name:{jct.Count}");

            JObject jbt = new JObject
            {
                { "Timi", "Gaming now" }
            };

            jct.Merge(jbt);
            Console.WriteLine($"Children tokens of the JContainer after merging a JObject that has no existing property name:{jct.Count}");

        }
    }
}
