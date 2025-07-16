using Newtonsoft.Json.Linq;
namespace Code_JToken_Children
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonFile = "JSON.json";
            string jsonContent = File.ReadAllText(jsonFile);
            var jtk = JToken.Parse(jsonContent);

            Console.WriteLine("使用Children方法获取直接的所有子节点------------------------------");
            var directChildrenTokens = jtk.Children<JToken>();
            foreach (var tk in directChildrenTokens)
            {
                Console.WriteLine("<-------------->");
                Console.WriteLine(".NET Type:{0},JTokenType:{1}", tk.GetType(), tk.Type);
                Console.WriteLine(tk);
            }

            Console.WriteLine("使用Children方法获取直接的所有JValue类型子节点------------------------------");
            var directChildrenJValueTokens = jtk.Children<JValue>();
            foreach (var jv in directChildrenJValueTokens)
            {
                Console.WriteLine("<-------------->");
                Console.WriteLine(".NET Type:{0},JTokenType:{1}", jv.GetType(), jv.Type);
                Console.WriteLine(jv);
            }

            Console.WriteLine("使用Children方法获取直接的所有数字类型子节点------------------------------");
            var directChildrenNumbers = jtk.Children<JValue>().Where(
                item => item.Type == JTokenType.Integer || item.Type == JTokenType.Float
                );
            foreach (var jn in directChildrenNumbers)
            {
                Console.WriteLine("<-------------->");
                Console.WriteLine(".NET Type:{0},JTokenType:{1}", jn.GetType(), jn.Type);
                Console.WriteLine(jn);
            };

            Console.WriteLine("使用Descendants方法获取所有子节点(递归获取嵌套的子节点)------------------------------");
            var allDescendants = ((JArray)jtk).Descendants();
            foreach (var des in allDescendants)
            {
                Console.WriteLine("<-------------->");
                Console.WriteLine(".NET Type:{0},JTokenType:{1}", des.GetType(), des.Type);
                Console.WriteLine(des);
            }


            Console.WriteLine("使用Descendants方法获取所有数字节点(递归获取嵌套的子节点)------------------------------");
            var allDescendantsNumber = ((JArray)jtk).Descendants().OfType<JValue>().Where(
                item => item.Type == JTokenType.Integer || item.Type == JTokenType.Float
                );
            foreach (var jn in allDescendantsNumber)
            {
                Console.WriteLine("<-------------->");
                Console.WriteLine(".NET Type:{0},JTokenType:{1}", jn.GetType(), jn.Type);
                Console.WriteLine(jn);
            }

            Console.WriteLine("使用Descendants方法获取所有属性节点(递归获取嵌套的子节点）------------------------------");
            var allDescendantsProperties = ((JArray)jtk).Descendants().OfType<JProperty>();
            foreach (var jp in allDescendantsProperties)
            {
                Console.WriteLine("<-------------->");
                Console.WriteLine("Property's Name: {0},Property's: Value{1}", jp.Name, jp.Value);
            }
        }
    }
}
