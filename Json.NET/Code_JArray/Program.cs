using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Code_JArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JArray jar = new() { 1, 2, 3 };

            Console.WriteLine(jar);
            Console.WriteLine("---------------------------------------");

            jar.Add("TMD");
            jar.Insert(0, "NMD");

            Console.WriteLine(jar);

            Console.WriteLine("---------------------------------------");

            var result = jar.Reverse();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
