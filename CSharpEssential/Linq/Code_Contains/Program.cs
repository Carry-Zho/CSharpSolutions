namespace Code_Contains
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<People> plist = new()
            { 
                new People(){ Name = "张三", Age = 1 },
                new People(){ Name = "李四", Age = 2 },
                new People(){ Name = "王五", Age = 3 }
            };

            People pp1 = new People() { Name = "张三", Age = 1 };

            People pp2 = plist[1];

            Console.WriteLine(plist.Contains(pp1));
            Console.WriteLine(plist.Contains(pp2));

        }
    }
    internal class People 
    {
        public string Name { get; set; } = "No body";
        public int Age { get; set; } = 0;
    }
}