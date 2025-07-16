using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Code_JSONPath_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonText = @"{'Name':'张三'}";
            // Parse the JSON text into a JObject
            JObject jsonObject = JObject.Parse(jsonText);
            // Use JSONPath to select the "Name" property
            JToken nameToken = jsonObject.SelectToken("$.Name");
            jsonObject.AddAnnotation("添加注释");

            // Convert the JToken to a string
            Console.WriteLine(jsonObject.ToString());

        }
    }
}
