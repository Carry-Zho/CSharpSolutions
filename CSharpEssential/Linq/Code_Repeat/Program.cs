namespace Code_Repeat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> strings = Enumerable.Repeat("I like programming.", 15);
            foreach (String str in strings)
            {
                Console.WriteLine(str);
            }
        }
    }
}
