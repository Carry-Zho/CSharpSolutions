using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Code_JTokenCast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonFile = "JSON.json";
            string jsonText = File.ReadAllText(jsonFile);

            // Parse the JSON text into a JToken
            JToken jtk = JToken.Parse(jsonText);

            //Select a specific token using a JSONPath expression
            var target = jtk.SelectToken("$.Test.items[0].name");
            Console.WriteLine(@$"target's JToken type:{target!.Type}, target's .NET Type:{target.GetType()},target's value:{target}");
            
            //使用ToObject<T>将target转换成 int 类型
            var castedTargetToIntUsingToObjectT = target.ToObject<int>();
            Console.WriteLine(@$"castedTargetToIntUsingToObjectT's .NET Type:{castedTargetToIntUsingToObjectT.GetType()},castedTargetToIntUsingToObjectT's value:{castedTargetToIntUsingToObjectT}");

            //使用Value<T>将target转换成 int 类型

            var castedTargetToIntUsingValueT = target.Parent!.Parent!.Value<int>("name");
            //castedTargetToIntUsingValueT = target.Parent!.Value<int>("name");   //Error,Value<T>仅适用于JObject、JArray

            Console.WriteLine(@$"castedTargetToIntUsingValueT's .NET Type:{castedTargetToIntUsingValueT.GetType()},castedTargetToIntUsingValueT's value:{castedTargetToIntUsingValueT}");
            
        }
    }
}
