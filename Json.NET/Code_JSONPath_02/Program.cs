using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Code_JSONPath_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonFile = "JSON.json";
            var token = JToken.ReadFrom(new JsonTextReader(new StringReader(File.ReadAllText(jsonFile))));

            string jsonPath = "$..*";

            ////逻辑错误
            //var metadataNodes = token.SelectTokens(jsonPath)
            //    .Where(token => token is JObject obj && obj.Properties().Any(p => p.Name.Contains("元数据")))
            //    .Select(obj => obj["创建时间"])
            //    .ToList();

            //foreach (var node in metadataNodes)
            //{
            //    Console.WriteLine(node);
            //}


            var results = token.SelectTokens(jsonPath).OfType<JObject>().Properties()
                .Where(jp => jp.Name.StartsWith("元数据_") && ((jp.Value as JObject)?.ContainsKey("创建时间") ?? false));

            foreach (var jp in results)
            {
                Console.WriteLine((jp.Value as JObject)!["创建时间"]);
            }

        }
    }
}
