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
        }
    }
}
