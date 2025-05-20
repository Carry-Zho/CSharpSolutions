namespace Code_Reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = [ 3, 2, 4, 5, 1];

            foreach (var item in numbers.OrderBy(orderL1 => orderL1))
                Console.WriteLine(item);

            Console.WriteLine("Let's reverse.");
            foreach (var item in numbers.OrderBy(orderL1 => orderL1).Reverse())
                Console.WriteLine(item);

        }
    }
}
