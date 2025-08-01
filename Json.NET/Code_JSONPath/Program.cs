using Newtonsoft.Json.Linq;

namespace Code_JSONPath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonContent = @"{
	                                    ""Name"":""ZhangSan"",
                                        ""Age"":21,
                                        ""Phones"":[
                                                    123,
                                                    456,
                                                    789	
                                                    ]
                                   }";
            JObject job = JObject.Parse(jsonContent);

            string jsonPath = "$..*";

            var results = job.SelectTokens(jsonPath);

            foreach (var result in results)
            {
                Console.WriteLine($"Current node's JTokenType:{result.Type}, current node's .NET type:{result.GetType()}----------------------------");
                Console.WriteLine(result);
            }
        }
    }
}
