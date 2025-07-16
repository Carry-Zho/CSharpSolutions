using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Code_DeserializationWithSettings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonFile = "JSON.txt";
            // Read the JSON file
            string json = File.ReadAllText(jsonFile);

            var pr = JsonConvert.DeserializeObject<JObject>(json)!;

            //未移除 null 值属性前输出
            foreach (var prop in pr.Properties())
            {
                Console.WriteLine($"{prop.Name}: {prop.Value}");
            }


            foreach (var prop in pr.Properties().ToList())
            {
                if (prop.Value.Type == JTokenType.Null)
                {
                    prop.Remove(); // 移除 null 值属性
                }
            }

            //移除 null 值属性后输出
            Console.WriteLine("-----------------------------------------");
            foreach (var prop in pr.Properties())
            {
                Console.WriteLine($"{prop.Name}: {prop.Value}");
            }

        }
    }
}
