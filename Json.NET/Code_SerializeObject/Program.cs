using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Code_SerializeObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JObject obj = new() { 
                ["Name"] = "Jone", 
                ["Age"] = DateTime.Now 
            };

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.DateFormatString = "yyyy-MMM-dd";
            settings.Formatting = Formatting.Indented;
            
            Console.WriteLine("默认序列化:");
            Console.WriteLine(JsonConvert.SerializeObject(obj));

            Console.WriteLine("自定义设定序列化:");
            Console.WriteLine(JsonConvert.SerializeObject(obj,settings));

        }
    }
}
