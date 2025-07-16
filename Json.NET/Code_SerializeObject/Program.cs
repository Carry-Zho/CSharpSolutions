using Newtonsoft.Json;
namespace Code_SerializeObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var obj = new { Name = "Jone", Age = 30};
            Console.WriteLine(obj.GetType());
            Console.WriteLine($"默认输出：{Environment.NewLine}{JsonConvert.SerializeObject(obj)}");

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
            Console.WriteLine($"缩进输出：{Environment.NewLine}{JsonConvert.SerializeObject(obj,settings)}");
        }
    }
}
