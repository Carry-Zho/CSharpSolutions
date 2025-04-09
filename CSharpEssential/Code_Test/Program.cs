namespace Code_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string Name, int Age) person = ("Zhangsan", 19);
            Console.WriteLine(person.ToString());
        }
    }
}