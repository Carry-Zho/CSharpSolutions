namespace Code_Prepend
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Alice", "Bob", "Charlie" };
            string[] namesPrependOne = names.Prepend("Ema").ToArray();

            //原集合
            foreach (var name in names)
            {
                Console.Write($"{name}  ");
            }

            Console.WriteLine();

            //新集合
            foreach (var name in namesPrependOne)
            {
                Console.Write($"{name}  ");
            }
        }
    }
}
