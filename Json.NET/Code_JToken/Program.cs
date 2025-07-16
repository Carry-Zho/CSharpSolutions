using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Code_JToken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonObjectFile = "JSON Array.txt";
            JToken jk = JsonConvert.DeserializeObject<JToken>(System.IO.File.ReadAllText(jsonObjectFile))!;

            foreach (JToken token in jk.Children())
            {
                Console.WriteLine(".NET Type: " + token.GetType());
                Console.WriteLine("Token Type: " + token.Type);
                Console.WriteLine(token);
            }

            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Children<JObject>()");
            foreach (JToken token in jk.Children<JObject>())
            {
                Console.WriteLine(".NET Type: " + token.GetType());
                Console.WriteLine("Token Type: " + token.Type);
                Console.WriteLine(token);
            }

            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Children<JArray>()");
            foreach (JToken token in jk.Children<JArray>())
            {
                Console.WriteLine(".NET Type: " + token.GetType());
                Console.WriteLine("Token Type: " + token.Type);
                Console.WriteLine(token);
            }

            //如何获取指定.NET类型的JValue
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Children<JValue>()");
            foreach (JToken token in jk.Children<JValue>().Where(v =>v.Type == JTokenType.Integer || v.Type == JTokenType.Float))
            {
                Console.WriteLine(".NET Type: " + token.GetType());
                Console.WriteLine("Token Type: " + token.Type);
                Console.WriteLine(token);
            }

        }
    }
}
