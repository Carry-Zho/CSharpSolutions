using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Code_AncestorsBeforeAfterSelf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonFile = "JSON.json";
            string jsonText = File.ReadAllText(jsonFile);
            var jtk = JToken.Parse(jsonText);
           
            var anchor = jtk.SelectToken("$.Address.City");
            Console.WriteLine("Anchor: " + anchor);

            Console.WriteLine("---------------------------------Ancestors the anchor---------------------------------");
            foreach (var ancestor in anchor!.Ancestors())
            {
                Console.WriteLine("Ancestor: \n" + ancestor);
                Console.WriteLine("<------------------------------>");
            }

            Console.WriteLine("Anchor: " + anchor);
            Console.WriteLine("---------------------------------AncestorsAndSelft the anchor---------------------------------");

            foreach (var ancestor in anchor!.AncestorsAndSelf())
            {
                Console.WriteLine("AncestorsAndSelf: \n" + ancestor);
                Console.WriteLine("<------------------------------>");
            }

            Console.WriteLine("Anchor: " + anchor);
            Console.WriteLine("---------------------------------BeforeSelf the anchor---------------------------------");
            foreach (var beforeSelf in anchor!.BeforeSelf())
            {
                Console.WriteLine("BeforeSelf: \n" + beforeSelf);
                Console.WriteLine("<------------------------------>");
            }

            Console.WriteLine("Anchor: " + anchor);
            Console.WriteLine("---------------------------------AfterSelf the anchor---------------------------------");
            foreach (var afterSelf in anchor!.AfterSelf())
            {
                Console.WriteLine("AfterSelf: \n" + afterSelf);
                Console.WriteLine("<------------------------------>");
            }

            Console.WriteLine(@"JProperty内的Value是独立的JToken，不参与Previous/Next链表关系（属性的Value JToken没有兄弟节点/没有同级节点),
因此JProperty内Value JToken的BeforSelf、AfterSelf返回空集合。");

            anchor = jtk.SelectToken("$.Hobbies[1]");
            Console.WriteLine("重新标定anchor = jtk.SelectToken(\"$.Hobbies[1]\")");

            Console.WriteLine("Anchor: " + anchor);
            Console.WriteLine("---------------------------------BeforeSelf the anchor---------------------------------");
            foreach (var beforeSelf in anchor!.BeforeSelf())
            {
                Console.WriteLine("BeforeSelf: \n" + beforeSelf);
                Console.WriteLine("<------------------------------>");
            }

            Console.WriteLine("Anchor: " + anchor);
            Console.WriteLine("---------------------------------AfterSelf the anchor---------------------------------");
            foreach (var afterSelf in anchor!.AfterSelf())
            {
                Console.WriteLine("AfterSelf: \n" + afterSelf);
                Console.WriteLine("<------------------------------>");
            }
        }
    }
}