using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Code_DescendantsAndSelf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonFile = @"JSON.json";
            TextReader reader = new StreamReader(jsonFile);

            JContainer jct = (JContainer)JToken.ReadFrom(new JsonTextReader(reader));

            //打印所有以"t"开头的属性的Name和Value
            var result = jct.Descendants().OfType<JProperty>().Where(
                p => p.Name.StartsWith("t")
                );

            foreach (var item in result)
                Console.WriteLine($"{item.Name}: {item.Value}");

            Console.WriteLine("=====================================");
            result = from jtk in jct.Descendants()
                     where jtk is JProperty && ((JProperty)jtk).Name.StartsWith("t")
                     select (JProperty)jtk;

            foreach (var item in result)
                Console.WriteLine($"{item.Name}: {item.Value}");

        }
    }
}
