using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Code_JObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JObject job = new JObject
            {
                { "Name", "张三" },
                { "Age", 30 }
            };

            Console.WriteLine(job["Address"].ToString());
            JArray jar = new()
            {
                1,
                2,
                3,
                4
            };
            Console.WriteLine(jar[4] == null); 
        }
    }
}
