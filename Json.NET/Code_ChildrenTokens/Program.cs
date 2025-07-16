using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Code_ChildrenTokens
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonContent = @"[1,2,3,'zhang','wang','li']";

            JContainer jct = (JContainer)JToken.Parse(jsonContent);

            Console.WriteLine($"Children tokens of the jct:{jct.Count}");

            jct.Merge(new JValue("zhao"));
            //Console.WriteLine($"Children tokens of the jct after merge:{jct.Count}");
            //foreach (JToken jToken in jct.Children())
            //{
            //    Console.WriteLine(jToken);
            //}

            Console.WriteLine(jct);


        }
    }
}
