namespace Code_Single
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new() { 3,4,5 };
            Console.WriteLine(list.SingleOrDefault(num => num <=3 ));
        }
    }
}