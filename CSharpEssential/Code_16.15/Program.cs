namespace Code_16._15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListMemberNames();
        }
        static void ListMemberNames()
        {
            IEnumerable<string> enumerableMethodNames =
                (from method in typeof(Enumerable).GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
                orderby method.Name
                select method.Name)
                .Distinct();

            foreach (string method in enumerableMethodNames)
                Console.Write($"{method},");

        }
    }
}
