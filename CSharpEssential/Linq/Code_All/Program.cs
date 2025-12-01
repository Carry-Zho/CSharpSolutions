namespace Code_All
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            Console.WriteLine(list.All(item => false));
            list.Add("没用的阿吉");
            list.Add("有用的三少爷");
            Console.WriteLine(list.All(item => false));
            Console.WriteLine(list.All(item => item.Contains("用的")));
        }
    }
}
