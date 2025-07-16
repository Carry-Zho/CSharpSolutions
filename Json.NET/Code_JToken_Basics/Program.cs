using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Code_JToken_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonFile = "JSON.json";
            string jsonText = File.ReadAllText(jsonFile);

            Console.WriteLine("原生JSON文本--------------------------------");
            Console.WriteLine(jsonText);


            StringReader reader = new StringReader(jsonText);
            JToken jtk = JToken.ReadFrom(new JsonTextReader(reader));
            JObject job = new JObject()
            {
                new JProperty("title","Testing"),
                new JProperty("price",21)
            };
            var firstBook = jtk["store"]["book"][0];
            firstBook.AddBeforeSelf(job);

            Console.WriteLine("添加一本书后的JSON文本--------------------------------");
            Console.WriteLine(jtk.ToString(Formatting.Indented));

            firstBook.Remove();
            Console.WriteLine("删除原生第一本书后的JSON文本--------------------------------");
            Console.WriteLine(jtk.ToString(Formatting.Indented));

            Console.WriteLine("将最后一辆自行车的价格更改为999后的JSON文本--------------------------------");
            var lastBicyclePrice = jtk.SelectToken("$..bicycle[-1:].price");
            lastBicyclePrice.Replace(new JValue(999));
            Console.WriteLine(jtk.ToString(Formatting.Indented));

        }
    }
}
