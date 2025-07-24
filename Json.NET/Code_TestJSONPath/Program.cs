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
            //

        }
    }
}
