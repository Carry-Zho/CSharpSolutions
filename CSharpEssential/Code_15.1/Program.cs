namespace Code_15._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sevenWorldBlunders = new()
            {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7"
            };
            Print(sevenWorldBlunders);

        }
        static void Print<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}