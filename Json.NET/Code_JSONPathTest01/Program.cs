using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Code_JSONPathTest01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonFile = "JSON.json";

            var token = JToken.ReadFrom(new JsonTextReader(new StringReader(File.ReadAllText(jsonFile))));

            string jsonPath = "$.['元数据_01','元数据_02']"; //JSONPath穷举以"元数据_"开头的JToken

            var results = token.SelectTokens(jsonPath);

            foreach (var result in results)
            {
                Console.WriteLine($"result' JTokenType:{result.Type}, result's .NET type:{result.GetType()}, result's 创建随时间:{result["创建时间"].ToString()}");
            }
        }
    }
}