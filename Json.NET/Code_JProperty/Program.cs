using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Code_JProperty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JObject job = new() { 
                new JProperty("name", "周鸣"),
                new JProperty("age", 22),
                new JProperty("isEmployed", true),
            };
            // 输出 JSON 字符串
            Console.WriteLine(job.ToString());
            Console.WriteLine("====================================");

            JProperty newProperty = new JProperty("city", new[]{ "c1","c2","c3"});
            job.Add(newProperty);

            // 输出更新后的 JSON 字符串
            Console.WriteLine(job.ToString());

            Console.WriteLine("====================================");
            // 遍历 JProperty
            foreach (var property in job.Properties())
            {
                Console.WriteLine($"Name: {property.Name}, Value: {property.Value}");
                Console.WriteLine("====================================");
            }

        }
    }
}
