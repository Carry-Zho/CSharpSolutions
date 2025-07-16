using Newtonsoft.Json;

namespace Code_SerializeObjectWithSettings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var prs = new Person
            {
                Name = "Jone",
                IsEmployed = true
                // Note: Age、Address is not set, so they will be 0 and null by default
            };

            Console.WriteLine("Serialize the object with default settings：——————————————————————");
            Console.WriteLine($"{JsonConvert.SerializeObject(prs)}");


            Console.WriteLine("Serialize the object with custom settings：缩进、忽略默认值属性——————————————————————");
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented, // 缩进
                DefaultValueHandling = DefaultValueHandling.Ignore // 忽略默认值属性
            };

            Console.WriteLine($"{JsonConvert.SerializeObject(prs,settings)}");

        }
    }
    internal class Person
    {
        public Person() { }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsEmployed { get; set; }
        public string Address { get; set; }
    }
}
