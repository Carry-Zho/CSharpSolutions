using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Code_Deserialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonObject = "{\"Name\":\"John\",\"Age\":30}";

            //dynamic obj = JsonConvert.DeserializeObject(jsonObject)!;
            //Console.WriteLine(obj.GetType());
            //Console.WriteLine($"Name {obj.Name}, Age {obj.Age}")


        }
    }
    public class Person
    {
        public required string Name { get; set; }
        public int Age { get; set; }
    }
}
