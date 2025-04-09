namespace Code_16._14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] keywords = {"a","b","c"};
            var numbers = new[] { 1, 2, 3 };

            IEnumerable<(string Word,int Number)> product =
                from keyword in keywords
                from number in numbers
                select (keyword, number);
            foreach (var item in product)
            {
                Console.WriteLine(item);
            }
        }
    }
}
